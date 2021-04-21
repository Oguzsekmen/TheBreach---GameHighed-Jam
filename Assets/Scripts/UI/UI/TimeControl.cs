using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public static TimeControl instance;
    public Text timeCounter;
    public Text gameOverText;
    public Text highScoreText;
    public Text winnerText;
    public Text winnerHighScoreText;

    bool gamePlaying;
    float highScore;
    TimeSpan timePlaying;    
    private float elapsedTime, startTime;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        TimeControl.instance.BeginTimer(); //Start
        //PlayerPrefs.DeleteKey("HighScore");        
    }
    private void Update()
    {
        if (gamePlaying)
        {
            elapsedTime = (Time.time - startTime)  /* /GameManager.gameSpeed*/;
            string timePlayingStr = "Time: " + elapsedTime.ToString("00");
            timeCounter.text = timePlayingStr;
        }
    }
    public void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
    }
    public void BeginTimer()
    {
        elapsedTime = 0f;
    }
   
    public void GameOver()
    {
        string highScoreStrings = null;
        float score = (1f / elapsedTime)*1000;
        int levelNo = SceneManager.GetActiveScene().buildIndex+1;
        switch (levelNo)
        {
            case 1:
                highScoreStrings = "HighScore1";
                break;
            case 2:
                highScoreStrings = "HighScore2";
                break;
            case 3:
                highScoreStrings = "HighScore3";
                break;
            case 4:
                highScoreStrings = "HighScore4";
                break;
            case 5:
                highScoreStrings = "HighScore5";
                break;
            case 6:
                highScoreStrings = "HighScore6";
                break;
            case 7:
                highScoreStrings = "HighScore7";
                break;
            case 8:
                highScoreStrings = "HighScore8";
                break;
            default:
                break;
        }
        gamePlaying = false;
        highScore = PlayerPrefs.GetFloat(highScoreStrings, 0f);
        if (highScore<score)
        {
            highScore = score; 
            PlayerPrefs.SetFloat(highScoreStrings, score);
        }
        gameOverText.text = "Score : 0";
        winnerText.text= "Score : " + score.ToString("00");
        highScoreText.text = "HighScore : " + highScore.ToString("00");
        winnerHighScoreText.text = "HighScore : " + highScore.ToString("00");
    }
    public void NextLevelScore()
    {
        float score = (1f / elapsedTime) * 1000;
        gamePlaying = false;
        highScore = PlayerPrefs.GetFloat("NextHighScore", 0f);
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetFloat("NextHighScore", score);
        }
        gameOverText.text = "Score : 0";
        winnerText.text = "Score : " + score.ToString("00");
        highScoreText.text = "HighScore : " + highScore.ToString("00");
        winnerHighScoreText.text = "HighScore : " + highScore.ToString("00");
    }

}
