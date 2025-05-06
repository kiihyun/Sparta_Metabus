using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyGameManager : MonoBehaviour
{
    static FlappyGameManager flappyGameManager;

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
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        uiManager.ExitMiniGame();
    }


    public void startGame()
    {
        SceneManager.LoadScene("MainMapScene");
        
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }

    

    public void EndMiniGame()
    {
        PlayerPrefs.SetInt("LastMiniGameScore", currentScore); // 점수 저장
        PlayerPrefs.Save();

        SceneManager.LoadScene("MainMapScene");
    }
}