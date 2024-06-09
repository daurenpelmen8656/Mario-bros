using UnityEngine;

public class FalseDoor : MonoBehaviour
{
    public GameObject gameOverScreen; // ������ �� GameOverScreen

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowGameOverScreen(); // ���������� GameOverScreen ��� �������������� ������
        }
    }

    void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // ���������� GameOverScreen
        }
    }
}
