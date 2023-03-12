using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float health;
    public GameObject Projectile;
    public float fireRate;
    public int projectileSpeed;
    public int bossPhase;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = GameObject.Find("Player").transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            health -= 5f;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        if (health == 100)
        {
            bossPhase = 1;
        }
        if (health == 50)
        {
            bossPhase = 2;
        }
        if (health == 25)
        {
            bossPhase = 3;
        }
    }

    void Shoot()
    {
        if (bossPhase == 1)
        {
            Vector3 difference = GameObject.Find("Player").transform.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity);
            projectile.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            projectile.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
        }
        if (bossPhase == 2)
        {
            Vector3 difference = GameObject.Find("Player").transform.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity);
            projectile.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            projectile.transform.position = new Vector3(projectile.transform.position.x - 0.1f, projectile.transform.position.y, projectile.transform.position.z);
            projectile.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;

            GameObject projectile2 = Instantiate(Projectile, transform.position, Quaternion.identity);
            projectile2.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            projectile2.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
            projectile2.transform.position = new Vector3(projectile2.transform.position.x + 0.1f, projectile2.transform.position.y, projectile2.transform.position.z);
        }
        if (bossPhase == 3)
        {
            Vector3 difference = GameObject.Find("Player").transform.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity);
            projectile.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            projectile.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;

            GameObject projectile2 = Instantiate(Projectile, transform.position, Quaternion.identity);
            projectile2.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            projectile2.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
            projectile2.transform.position = new Vector3(projectile2.transform.position.x + 0.1f, projectile2.transform.position.y, projectile2.transform.position.z);

            GameObject projectile3 = Instantiate(Projectile, transform.position, Quaternion.identity);
            projectile3.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            projectile3.GetComponent<Rigidbody2D>().velocity = transform.right * projectileSpeed;
            projectile3.transform.position = new Vector3(projectile3.transform.position.x - 0.1f, projectile3.transform.position.y, projectile3.transform.position.z);
        }

    }
}
