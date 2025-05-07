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
        // ù �ε��̸� ��� ���·� ���� (Ÿ��Ʋ ȭ�鿡�� ��ư���� �����ϵ���)
        if (!isFirstLoading)
        {
            StartGame(); // �� ��° ���� �� �ε� �� �ڵ� ����
        }
        else
        {
            isFirstLoading = false; // ù �ε� �÷��� ����
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
    //    PlayerPrefs.SetInt("LastMiniGameScore", currentScore); // ���� ����
    //    PlayerPrefs.Save();

    //    SceneManager.LoadScene("MainMapScene");
    //}
}