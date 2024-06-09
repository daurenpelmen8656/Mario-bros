using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrueDoor : MonoBehaviour
{
    public GameObject winScreen; // Ссылка на WinScreen
    public Image[] stars; // Массив для звезд
    public Sprite fullStar; // Спрайт для полной звезды
    public Sprite halfStar; // Спрайт для половины звезды
    public CoinManager coinManager; // Ссылка на CoinManager

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowWinScreen(); // Показываем WinScreen при взаимодействии игрока
        }
    }

    void ShowWinScreen()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true); // Активируем WinScreen
            UpdateStars(); // Обновляем звезды в зависимости от собранных фруктов
        }
    }

    void UpdateStars()
    {
        int totalCoins = coinManager.totalCoins; // Общее количество фруктов
        int collectedCoins = coinManager.collectedCoins; // Собранные фрукты

        float percentage = (float)collectedCoins / totalCoins;

        for (int i = 0; i < stars.Length; i++)
        {
            if (percentage >= (i + 1) * 0.33f)
            {
                stars[i].sprite = fullStar;
            }
            else if (percentage >= (i + 1) * 0.165f)
            {
                stars[i].sprite = halfStar;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
