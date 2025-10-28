using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject homeUI;
    public TextMeshProUGUI homeNowScoreText;
    public TextMeshProUGUI homeBestScoreText;
    void Start()
    {
        ShowHome(true);
        Time.timeScale = 0f;

        var gm = GameManager_TappyPlane.Instance;
        int best = gm != null ? gm.BestScore : PlayerPrefs.GetInt("BestScore", 0);
        SetScores(0, best);
    }


    public void SetRestart()
    {
        ShowHome(true);
        Time.timeScale = 0f;
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null) scoreText.text = score.ToString();
    }

    public void ShowHome(bool show)
    {
        if (homeUI != null) homeUI.SetActive(show);
    }
    public void SetScores(int now, int best)
    {
        if (scoreText) scoreText.text = now.ToString();
        if (homeNowScoreText) homeNowScoreText.text = now.ToString();
        if (homeBestScoreText) homeBestScoreText.text = best.ToString();
    }

    public void OnClickStart()
    {
        var gm = GameManager_TappyPlane.Instance;
        if (gm == null) return;

        if (gm.IsGameOver)
        {
           
            gm.RestartGame();

            return;
        }


        ShowHome(false);
        Time.timeScale = 1f;
        gm.StartGame();
    }
    public void OnClickDebug() { Debug.Log("StartButton clicked!"); }
    public void OnClickExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene"); 
    }
}
