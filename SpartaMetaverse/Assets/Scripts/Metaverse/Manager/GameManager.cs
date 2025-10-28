using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController player { get; private set; }
    //private ResourceController _playerResourceController;

    [SerializeField] private int currentWaveIndex = 0;


    //private UIManager uiManager;
    public static bool isfirstLoading = true;

    public void GameOver()
    {
        //uiManager.SetGameOver();
    }
}
