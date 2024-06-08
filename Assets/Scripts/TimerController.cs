using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float timeRemaining = 60f; // Время в секундах
    public Text timerText; // UI элемент для отображения времени
    public GameObject gameOverScreen; // Ссылка на объект экрана Game Over

    private bool timerIsRunning = false;

    void Start()
    {
        // Запускаем таймер
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                ShowGameOverScreen();
            }
        }
    }

    void UpdateTimerText(float timeToDisplay)
    {
        timeToDisplay += 1; // Чтобы компенсировать отставание таймера
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTime(float time)
    {
        timeRemaining += time;
        UpdateTimerText(timeRemaining);
    }

    void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // Активируем экран Game Over, если он установлен
        }
    }
}
