using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameManager : MonoBehaviour
{
    static FlappyGameManager flappyGameManager;
    public static bool isFirstLoading = true;

    public static FlappyGameManager Instance
    {
        get { return flappyGameManager; }
    }

    private int currentScore = 0;

    FlappyUIManager uiManager;

    public FlappyUIManager UIManager
    {
        get { return uiManager; }
    }
    private void Awake()
    {
        flappyGameManager = this;
        uiManager = FindObjectOfType<FlappyUIManager>();
    }

    private void Start()
    {
        // Score 초기화만 담당
        ScoreManager.Instance.ResetScore();
        // 나머지 흐름은 MiniGameController에 맡김
    }


    //public void GameOver()
    //{
    //    Debug.Log("Game Over");
    //    uiManager.ExitMiniGame();
    //}


    public void StartGame()
    {
        SceneManager.LoadScene("MainMapScene");
        
    }


    

    //public void EndMiniGame()
    //{
    //    PlayerPrefs.SetInt("LastMiniGameScore", currentScore); // 점수 저장
    //    PlayerPrefs.Save();

    //    SceneManager.LoadScene("MainMapScene");
    //}
}