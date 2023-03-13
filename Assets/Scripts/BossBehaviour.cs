using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float health;
    public int phase;
    // raycast
    public Ray2D ray;
    public float rayLength;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (health <= 100)
        {
            phase = 1;
        }
        if (health <= 50)
        {
            phase = 2;
        }
        if (health <= 25)
        {
            phase = 3;
        }
    }


    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        if (phase == 1)
        {
            // cast a ray left and right
            // if the ray hits the player, move towards the player
            ray = new Ray2D(transform.position, Vector2.left);
            Debug.DrawRay(transform.position, ray.direction * rayLength, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, ray.direction, rayLength);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider);
                if (hit.collider.tag == "Player")
                {
                    transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * 10f);

                    transform.localScale = new Vector3(8.2655f, 8.2655f, 8.2655f);
                }
            }
            ray = new Ray2D(transform.position, Vector2.right);
            Debug.DrawRay(transform.position, ray.direction * rayLength, Color.red);
            hit = Physics2D.Raycast(transform.position, ray.direction, rayLength);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider);
                if (hit.collider.tag == "Player")
                {
                    transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * 10f);

                    transform.localScale = new Vector3(-8.2655f, 8.2655f, 8.2655f);

                }
            }
        }
        if (phase == 2)
        {
            // cast a ray left and right
            // if the ray hits the player, move towards the player
            ray = new Ray2D(transform.position, Vector2.left);
            Debug.DrawRay(transform.position, ray.direction * rayLength, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, ray.direction, rayLength);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider);
                if (hit.collider.tag == "Player")
                {
                    transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * 10f);

                    transform.localScale = new Vector3(8.2655f, 8.2655f, 8.2655f);
                }
            }
            ray = new Ray2D(transform.position, Vector2.right);
            Debug.DrawRay(transform.position, ray.direction * rayLength, Color.red);
            hit = Physics2D.Raycast(transform.position, ray.direction, rayLength);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider);
                if (hit.collider.tag == "Player")
                {
                    transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * 10f);

                    transform.localScale = new Vector3(-8.2655f, 8.2655f, 8.2655f);

                }
            }

            // cast a ray up
            // if the ray hits the player, move towards the player
            ray = new Ray2D(transform.position, Vector2.up);
            Debug.DrawRay(transform.position, ray.direction * rayLength, Color.red);
            hit = Physics2D.Raycast(transform.position, ray.direction, rayLength);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider);
                if (hit.collider.tag == "Player")
                {
                    transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position, Time.deltaTime * 10f);

                    transform.localScale = new Vector3(8.2655f, 8.2655f, 8.2655f);
                }
            }
        }
        if (phase == 3)
        {
            // detect if the player is in the boss's range
            // if the player is in the boss's range, move towards the player
            // if the player is not in the boss's range, move towards the center of the screen
            GameObject player = GameObject.Find("Player");

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 10f);

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Projectile")
            {
                health -= 10;
                Destroy(collision.gameObject);
            }
        }
    }
}
