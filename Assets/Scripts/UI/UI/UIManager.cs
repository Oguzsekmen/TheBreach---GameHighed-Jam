using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingMenu;
    public GameObject pauseMenu;
    public GameObject inGameScreen;
    public GameObject winnerScreen;
    public GameObject gameOverScreen;
    LevelBar levelBar;
    bool gamePause = false;
    bool gamePlaying = false;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //private void Start()
    //{
    //    Time.timeScale = 0;
    //    mainMenu.SetActive(true);
    //    inGameScreen.SetActive(false);
    //    settingMenu.SetActive(false);
    //    pauseMenu.SetActive(false);
    //    winnerScreen.SetActive(false);
    //    gameOverScreen.SetActive(false);
    //    player.SetActive(false);
    //}

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && gamePlaying)
        {
            if (gamePause)
            {
                ResumeButton();
            }
            else
            {
                PauseButton();
            }
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Winner();
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    GameOver();
        //}   
    }
    private void Start()
    {
        Time.timeScale = 0;
        mainMenu.SetActive(true);
        inGameScreen.SetActive(false);
        settingMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winnerScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        player.SetActive(false);
    }

    public void StartButton()
    {
        // SceneManager.LoadScene(1); 
        Debug.Log("Game Playing");
        TimeControl.instance.BeginGame();
        Time.timeScale = 1;
        mainMenu.SetActive(false);
        inGameScreen.SetActive(true);
        gamePlaying = true;
    }
    public void SettingButton()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
        gamePlaying = false;
    }
    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseMenu.SetActive(true);
        gamePause = true;
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        inGameScreen.SetActive(true);
        gamePause = false;
    }
    public void Winner()
    {
        inGameScreen.SetActive(false);
        winnerScreen.SetActive(true);
        TimeControl.instance.GameOver();
        gamePlaying = false;
    }
    public void NextLevelButton()
    {
        Debug.Log("Next Level!");
        SceneManager.LoadScene(1);
        inGameScreen.SetActive(true);
        winnerScreen.SetActive(false);
        TimeControl.instance.BeginGame();
    }
    public void RestartButton()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(0);
        gamePlaying = false;
    }
    public void GameOver()
    {
        inGameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        TimeControl.instance.GameOver();
        Time.timeScale = 0f;
        gamePlaying = false;
    }
    public void NextLevel()
    {
        inGameScreen.SetActive(false);
        winnerScreen.SetActive(true);
    }
}
