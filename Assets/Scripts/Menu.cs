using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    public Button startGameButton;

    public Button menuButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            startButton.onClick.AddListener(StartInputTutorial);
            quitButton.onClick.AddListener(QuitGame);
            startGameButton.onClick.AddListener(StartGame);
        }

        if (SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "Lose")
        {
            menuButton.onClick.AddListener(menu);
        }
        if (SceneManager.GetActiveScene().name == "InputTutorial")
        {
            startGameButton.onClick.AddListener(StartGame);
        }
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

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartInputTutorial()
    {
        SceneManager.LoadScene("InputTutorial");
    }




}
