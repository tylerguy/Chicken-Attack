using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce;
    public Rigidbody2D rb;
    public Ray2D ray;
    public bool isGrounded;
    public GameObject Projectile;
    public Transform rayorigin;

    public float speed;

    public Transform bulletSpawn;

    public int ammo;
    public float currentHealth = 0f;
    public float maxHealth = 100f;
    public int projectileSpeed;
    private Animator _animator;

    private bool CanDash = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
        GameObject ammoText = GameObject.Find("Ammo");
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {

        Vector2 rayOrigin = new Vector2(rayorigin.position.x, rayorigin.position.y);
        ray = new Ray2D(transform.position, Vector2.down);
        Debug.DrawRay(rayOrigin, ray.direction * 0.05f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, ray.direction, 0.05f);


        if (hit.collider != null)
        {
            if (hit.collider.tag == "Ground")
            {
                isGrounded = true;
            }
        }
        else
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ammoText = GameObject.Find("Ammo");
        if (Input.GetKey(KeyCode.D))
        {
            // update the player's animation
            _animator.SetBool("isMoving", true);
            // get player's current scale and flip it on the x axis
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            // apply the scale
            transform.localScale = scale;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            // flip the ammo text
            ammoText.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("isMoving", true);
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            // flip the ammo text
            ammoText.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                _animator.SetBool("jump", true);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetBool("jump", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0)
            {
                ammo -= 1;
                // get the direction the player is facing
                _animator.SetBool("isShooting", true);
                Vector3 direction = transform.localScale.x > 0 ? Vector3.right : Vector3.left;
                GameObject projectile = Instantiate(Projectile, bulletSpawn.position, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            }
            else if (ammo <= 0)
            {
                _animator.SetBool("isShooting", false);
                StartCoroutine(WaitForReload());
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("isShooting", false);
        }
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool("isMoving", false);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            // add rigidbody force in the direction the player is facing
            if (CanDash)
            {
                StartCoroutine(Dash());
            }
        }

        // get the textmeshpro component
        TMPro.TextMeshPro ammoTextMesh = ammoText.GetComponent<TMPro.TextMeshPro>();
        // set the text to the ammo value
        ammoTextMesh.text = ammo.ToString();
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(0.5f);
            isGrounded = true;
        }
    }

    IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(0.5f);
        ammo = 10;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        _animator.SetBool("damageTaken", true);
        if (currentHealth <= 0f)
        {
            Die();
        }
        _animator.SetBool("damageTaken", false);
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    IEnumerator Dash()
    {
        CanDash = false;
        // get the direction the player is facing
        Vector3 direction = transform.localScale.x > 0 ? Vector3.right : Vector3.left;
        // add rigidbody force in the direction the player is facing
        rb.AddForce(direction * 1000f);
        yield return new WaitForSeconds(2f);
        CanDash = true;
    }


}


