using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
    // if start game button is pressed, load the game scene
    public void StartGame()
    {
        SceneManager.LoadScene("BossLevel");
    }

    // if quit game button is pressed, quit the game
    public void QuitGame()
    {
        Application.Quit();

    }




}
