using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // ���� ���ٿ� �ν��Ͻ�
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;

    void Awake()
    {
        // �ν��Ͻ��� ������ �ڽ��� �Ҵ�
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ� ����
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        Debug.Log($"============{score}");
        score += value;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"{score}";

        if (bestText != null)
            bestText.text = $"{PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }
    public void SaveHighScore()
    {
        int bestScore = PlayerPrefs.GetInt("HighScore", 0); // ����� �ְ� ���� �ҷ�����

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("HighScore", score); // �ְ� ���� ����
            PlayerPrefs.Save(); // ��� ����
        }
    }
    public void EndGame()
    {
        ScoreManager.Instance.SaveHighScore(); // �ְ� ���� ����
        PlayerPrefs.SetInt("LastScore", ScoreManager.Instance.score); // ���� ���� ����
        PlayerPrefs.Save();

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMapScene"); // ���θ� ����
    }
}