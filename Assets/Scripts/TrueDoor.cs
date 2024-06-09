using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrueDoor : MonoBehaviour
{
    public GameObject winScreen; // ������ �� WinScreen
    public Image[] stars; // ������ ��� �����
    public Sprite fullStar; // ������ ��� ������ ������
    public Sprite halfStar; // ������ ��� �������� ������
    public CoinManager coinManager; // ������ �� CoinManager

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowWinScreen(); // ���������� WinScreen ��� �������������� ������
        }
    }

    void ShowWinScreen()
    {
        if (winScreen != null)
        {
            winScreen.SetActive(true); // ���������� WinScreen
            UpdateStars(); // ��������� ������ � ����������� �� ��������� �������
        }
    }

    void UpdateStars()
    {
        int totalCoins = coinManager.totalCoins; // ����� ���������� �������
        int collectedCoins = coinManager.collectedCoins; // ��������� ������

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
