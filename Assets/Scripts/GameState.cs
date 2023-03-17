using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public GameObject middleCollider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // while the player or boss is alive, the game is running
        if (GameObject.Find("Player") != null && GameObject.Find("Boss") != null)
        {
            // do nothing
        }
        else
        {
            // if the player is dead, the game is over
            if (GameObject.Find("Player") == null)
            {
                Debug.Log("Game Over");
                SceneManager.LoadScene("Lose");
            }
            // if the boss is dead, the player wins
            if (GameObject.Find("Boss") == null)
            {
                Debug.Log("You Win");
                SceneManager.LoadScene("Win");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if the player colliders with the middle collider with tag "CamPos" the camera will move to the right
        if (other.gameObject.tag == "Player")
        {
            cam.transform.position = new Vector3(3, 5, -29.5f);
            // wait for 1 second
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        middleCollider.GetComponent<BoxCollider2D>().isTrigger = false;

    }
}
