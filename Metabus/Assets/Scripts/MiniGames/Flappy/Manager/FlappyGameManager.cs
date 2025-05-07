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
        // 첫 로딩이면 대기 상태로 유지 (타이틀 화면에서 버튼으로 시작하도록)
        if (!isFirstLoading)
        {
            StartGame(); // 두 번째 이후 씬 로딩 시 자동 시작
        }
        else
        {
            isFirstLoading = false; // 첫 로딩 플래그 해제
        }
        //uiManager.UpdateScore(0);
        //ScoreManager.Instance;
        ScoreManager.Instance.ResetScore();
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