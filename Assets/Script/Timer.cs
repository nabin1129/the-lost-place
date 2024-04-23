using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float maxTime;
    float remainingTime;
    bool gameStarted = false;
    bool gameOver = false;

    public GameObject GameOverScreen;

    void Start()
    {
        remainingTime = maxTime;
        UpdateTimerText();
        GameOverScreen.SetActive(false); // Hide game over screen initially
    }

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Q)) // Start timer when player presses "O" key
        {
            gameStarted = true;
        }

        if (gameStarted)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                GameOver();
            }

            UpdateTimerText();

            // Hide game over screen when timer is white
            if (timerText.color == Color.white)
            {
                GameOverScreen.SetActive(false);
            }
        }

        // Restart timer when player presses "E" key
        if (Input.GetKeyDown(KeyCode.E))
        {
            remainingTime = maxTime;
            gameStarted = true;
            gameOver = false;
            UpdateTimerText();
            GameOverScreen.SetActive(false);
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        GameOverScreen.SetActive(true);
        gameOver = true;
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Change text color based on remaining time
        if (remainingTime <= 5)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.white;
        }
    }
}