using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public GameObject gameOverPanel;   // ���� �� ǥ���� UI
    public TextMeshProUGUI resultText;
    public float returnDelay = 2.5f;   // ���ͱ��� ��� �ð�

    private bool gameOver = false;     // ���� ���� Ȯ��
    private float elapsedTime = 0f;    // �ð� ������ ����


    public static MiniGameController Instance { get; private set; }

    public GameObject startPanel;       // ���� UI
    public Button startButton;

    private bool gameStarted = false;

    void Start()
    {
        gameOver = false;
        elapsedTime = 0f;
        gameOverPanel.SetActive(false);

        startPanel.SetActive(true);
        startButton.onClick.AddListener(OnStartButtonClicked);

        ScoreManager.Instance.ResetScore(); // �߰�: ���� ���� �� ���� ����

        Time.timeScale = 0f; // ���� �� ���� ����
    }


    void OnStartButtonClicked()
    {
        startPanel.SetActive(false);
        gameStarted = true;
        Time.timeScale = 1f; // ���� ����
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        gameOver = false;
        gameStarted = false;
        Time.timeScale = 1f; // Ȥ�ö� ���� ������ �� ���ƿ� �� ����
    }


    public void EndMiniGame(bool success, int finalScore)
    {
        if (gameOver) return;
        gameOver = true;

        Time.timeScale = 1f;
        // ���� ����
        ScoreManager.Instance.score = finalScore;
        ScoreManager.Instance.SaveHighScore();
        PlayerPrefs.SetInt("LastScore", finalScore);
        PlayerPrefs.Save();

        // UI ���
        gameOverPanel.SetActive(true);
        resultText.text = success ? "Success!" : "Fail!";

        // Ÿ�̸� �ʱ�ȭ
        elapsedTime = 0f;
    }

    void Update()
    {
        // ���� ���� �� �ð� ���� �� ���� �ð� �� �� ����
        if (gameOver)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= returnDelay)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMapScene");
            }
        }
    }
}

