using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MiniGameType
{
    FlappyBird,
    Stack,
    // 나중에 더 추가 가능
}
public class TriggerZone : MonoBehaviour
{
    public GameObject popupUI;

    public string requiredTag = "Player";
    public GameObject miniGameUIPrompt;
    public MiniGameType miniGameType;

    private bool canStart = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(requiredTag))
        {
            canStart = true;
            miniGameUIPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == null || !other.CompareTag(requiredTag)) return;
        if (miniGameUIPrompt != null)
        {
            canStart = false;
            miniGameUIPrompt.SetActive(false);
        }
    }

    private void Update()
    {
        if (canStart && Input.GetKeyDown(KeyCode.E))
        {
            StartMiniGame();
        }
    }
    void StartMiniGame()
    {
        SceneManager.LoadScene("FlappyBirdScene");
    }
}
