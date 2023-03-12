using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce;
    public Rigidbody2D rb;
    public Ray2D ray;
    public bool isGrounded;
    public GameObject Projectile;
    public Transform rayorigin;
    public GameObject shield;
    public float health;

    public float speed;


    public int projectileSpeed;
    void Start()
    {

    }

    void FixedUpdate()
    {

        Vector2 rayOrigin = new Vector2(rayorigin.position.x, rayorigin.position.y);
        ray = new Ray2D(transform.position, Vector2.down);
        Debug.DrawRay(rayOrigin, ray.direction * 0.05f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, ray.direction, 0.05f);


        if (hit.collider != null)
        {
            Debug.Log(hit.collider);
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
        if (Input.GetKey(KeyCode.D))
        {
            // transform.Translate(Vector2.right * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // transform.Translate(Vector2.left * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;

            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 direction = mousePos - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            GameObject projectile = Instantiate(Projectile, transform.position, rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (!shield.activeInHierarchy)
            {
                shield.SetActive(true);
                StartCoroutine(ShieldOff());
            }
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator ShieldOff()
    {
        yield return new WaitForSeconds(5);
        shield.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BossProjectile")
        {
            if (this.gameObject.tag == "Player")
            {
                health -= 10;
            }
        }
    }

}


