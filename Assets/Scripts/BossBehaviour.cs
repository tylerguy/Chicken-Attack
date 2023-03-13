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
                    transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position, 0.05f);
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
                    transform.position = Vector2.MoveTowards(transform.position, hit.collider.transform.position, 0.05f);
                }
            }
        }
        if (phase == 2)
        {

        }
        if (phase == 3)
        {

        }
    }
}
