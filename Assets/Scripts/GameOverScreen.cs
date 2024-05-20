using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText; // Текстовый элемент для отображения очков

    // Метод для установки экрана Game Over и отображения очков
    public void Setup(int score)
    {
        gameObject.SetActive(true); // Активируем экран Game Over
        pointsText.text = score.ToString() + " POINTS"; // Устанавливаем текст с количеством очков
    }

    // Метод для кнопки перезапуска уровня
    public void RestartButton()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // Получаем текущую сцену
        SceneManager.LoadScene(currentScene.name); // Перезагружаем текущую сцену
    }

    // Метод для кнопки выхода в главное меню
    public void ExitButton()
    {
        SceneManager.LoadScene("Main"); // Загружаем сцену с именем "Main"
    }
}

