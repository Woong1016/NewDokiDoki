using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public Text gameOverText;
    public GameObject pauseUI;
    public GameObject pauseUI2;
    public float gameDuration = 60f; // 게임 지속 시간 (초)
    private float gameTime;
    private bool isGameOver = false;

    void Start()
    {
        timerText.text = "Time: " + gameDuration.ToString("F1");
        gameTime = 0f;
        UpdateTimer();

        gameOverText.gameObject.SetActive(false);
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            gameTime += Time.deltaTime;

            if (gameTime >= gameDuration)
            {
                EndGame();
            }

            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        timerText.text = "Time: " + Mathf.Clamp(gameTime, 0, gameDuration).ToString("F1");
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f; // 게임 일시 정지
        pauseUI.SetActive(true);

        // 게임 종료 처리 추가 (예: 씬 전환 또는 게임 재시작)
    }
}
