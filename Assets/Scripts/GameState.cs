using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public GameObject middleTrigger;
    public GameObject middleCollider;
    private GameObject player;
    private GameObject boss;
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
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
            middleCollider.SetActive(true);
        }
    }
}
