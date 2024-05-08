using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float HP = 100f;
    public Image Bar;
    public GameObject gameOverScreen; // ������ �� ������ ������ Game Over

    void Start()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        Bar.fillAmount = HP / 100;

        if (HP <= 0)
        {
            ShowGameOverScreen(); // ���������� ����� Game Over ��� ������ ������
            gameObject.SetActive(false); // ��������� ������ � ��������� ������
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake") || collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage(5); // ������� ���� ��� ������������ � ����� ��� ������
        }
    }

    private void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // ���������� ����� Game Over
        }
    }
}



