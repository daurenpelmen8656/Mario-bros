using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText; // ��������� ������� ��� ����������� �����

    // ����� ��� ��������� ������ Game Over � ����������� �����
    public void Setup(int score)
    {
        gameObject.SetActive(true); // ���������� ����� Game Over
        pointsText.text = score.ToString() + " POINTS"; // ������������� ����� � ����������� �����
    }

    // ����� ��� ������ ����������� ������
    public void RestartButton()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // �������� ������� �����
        SceneManager.LoadScene(currentScene.name); // ������������� ������� �����
    }

    // ����� ��� ������ ������ � ������� ����
    public void ExitButton()
    {
        SceneManager.LoadScene("Main"); // ��������� ����� � ������ "Main"
    }
}

