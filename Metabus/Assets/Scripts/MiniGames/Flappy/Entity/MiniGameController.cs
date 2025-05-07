using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public GameObject gameOverPanel;   // 종료 시 표시할 UI
    public TextMeshProUGUI resultText;
    public float returnDelay = 2.5f;   // 복귀까지 대기 시간

    private bool gameOver = false;     // 종료 상태 확인
    private float elapsedTime = 0f;    // 시간 누적용 변수


    public static MiniGameController Instance { get; private set; }

    public GameObject startPanel;       // 시작 UI
    public Button startButton;

    private bool gameStarted = false;

    void Start()
    {
        gameOver = false;
        elapsedTime = 0f;
        gameOverPanel.SetActive(false);

        startPanel.SetActive(true);
        startButton.onClick.AddListener(OnStartButtonClicked);

        ScoreManager.Instance.ResetScore(); // 추가: 게임 시작 시 점수 리셋

        Time.timeScale = 0f; // 시작 전 게임 멈춤
    }


    void OnStartButtonClicked()
    {
        startPanel.SetActive(false);
        gameStarted = true;
        Time.timeScale = 1f; // 게임 시작
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
        Time.timeScale = 1f; // 혹시라도 이전 씬에서 안 돌아온 걸 방지
    }


    public void EndMiniGame(bool success, int finalScore)
    {
        if (gameOver) return;
        gameOver = true;

        Time.timeScale = 1f;
        // 점수 저장
        ScoreManager.Instance.score = finalScore;
        ScoreManager.Instance.SaveHighScore();
        PlayerPrefs.SetInt("LastScore", finalScore);
        PlayerPrefs.Save();

        // UI 출력
        gameOverPanel.SetActive(true);
        resultText.text = success ? "Success!" : "Fail!";

        // 타이머 초기화
        elapsedTime = 0f;
    }

    void Update()
    {
        // 게임 종료 후 시간 누적 → 일정 시간 후 맵 복귀
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

