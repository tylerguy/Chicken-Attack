using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update
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
                SceneManager.LoadScene("Menu");
            }
            // if the boss is dead, the player wins
            if (GameObject.Find("Boss") == null)
            {
                Debug.Log("You Win");
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
