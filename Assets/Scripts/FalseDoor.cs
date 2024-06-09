using UnityEngine;

public class FalseDoor : MonoBehaviour
{
    public GameObject gameOverScreen; // Ссылка на GameOverScreen

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowGameOverScreen(); // Показываем GameOverScreen при взаимодействии игрока
        }
    }

    void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // Активируем GameOverScreen
        }
    }
}
