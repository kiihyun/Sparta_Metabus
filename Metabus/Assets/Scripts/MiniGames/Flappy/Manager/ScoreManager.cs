using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // 전역 접근용 인스턴스
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestText;

    void Awake()
    {
        // 인스턴스가 없으면 자신을 할당
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 중복 방지
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
        int bestScore = PlayerPrefs.GetInt("HighScore", 0); // 저장된 최고 점수 불러오기

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("HighScore", score); // 최고 점수 갱신
            PlayerPrefs.Save(); // 즉시 저장
        }
    }
    public void EndGame()
    {
        ScoreManager.Instance.SaveHighScore(); // 최고 점수 저장
        PlayerPrefs.SetInt("LastScore", ScoreManager.Instance.score); // 현재 점수 저장
        PlayerPrefs.Save();

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMapScene"); // 메인맵 복귀
    }
}