using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public Text gameOverText;
    public GameObject pauseUI;
    public GameObject pauseUI2;
    public float gameDuration = 60f; // ���� ���� �ð� (��)
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
        Time.timeScale = 0f; // ���� �Ͻ� ����
        pauseUI.SetActive(true);

        // ���� ���� ó�� �߰� (��: �� ��ȯ �Ǵ� ���� �����)
    }
}
