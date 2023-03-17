using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 3f);
    }

    // detect collision with enemy
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            BossBehaviour boss = other.gameObject.GetComponent<BossBehaviour>();
            boss.currentHealth -= 3;
        }
    }
}
