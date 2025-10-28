using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_TappyPlane : MonoBehaviour
{
    static GameManager_TappyPlane gameManager;
    public static GameManager_TappyPlane Instance { get { return gameManager; } }
    int currentScore = 0;
    public int BestScore { get; private set; }
    public bool IsStarted { get; private set; } = false;
    public bool IsGameOver { get; private set; } = false;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
        BestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void Start()
    {
        currentScore = 0;
        uiManager.SetScores(currentScore, BestScore);

        IsStarted = false;
        IsGameOver = false;
    }
    public void StartGame()
    {
        currentScore = 0;
        IsStarted = true;
        IsGameOver = false;
        uiManager.SetScores(currentScore, BestScore);
    }
    // Update is called once per frame
    public void GameOver()
    {
        Debug.Log("Game Over");
        IsGameOver = true;
        IsStarted = false;

        if (currentScore > BestScore)
        {
            BestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", BestScore);
            PlayerPrefs.Save();
        }

        uiManager.SetScores(currentScore, BestScore); // 홈패널에 현재/최고 표시
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
    }

}
