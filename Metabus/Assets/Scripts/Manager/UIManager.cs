using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI lastScoreText;
    public TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        int bestScore = PlayerPrefs.GetInt("HighScore", 0);

        lastScoreText.text = $"Last Score: {lastScore}";
        bestScoreText.text = $"Best Score: {bestScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
