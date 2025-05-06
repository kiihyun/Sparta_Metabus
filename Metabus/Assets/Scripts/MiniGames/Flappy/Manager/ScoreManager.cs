using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // ���� ���ٿ� �ν��Ͻ�
    public int score = 0;
    public Text scoreText;

    void Awake()
    {
        // �ν��Ͻ��� ������ �ڽ��� �Ҵ�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� �ʵ��� ����
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
        score += value;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"����: {score}";
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }
}