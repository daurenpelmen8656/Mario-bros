using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float HP = 100f; // ���������� ��� �������� �������� ��������
    public Image Bar; // UI ������� ��� ����������� ��������
    public GameObject gameOverScreen; // ������ �� ������ ������ Game Over

    private float fallStartY; // ���������� ��� ������������ ��������� ������ �������
    private bool isFalling; // ���� ��� ��������, ������ �� �����

    private PlayerMovement playerMovement; // ������ �� ������ PlayerMovement ��� �������� ����

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); // �������� ������ �� ������ PlayerMovement
        UpdateHealthBar(); // ��������� ����������� �������� � ������
    }

    void UpdateHealthBar()
    {
        Bar.fillAmount = HP / 100; // ��������� �������� ����� ��������

        if (HP <= 0)
        {
            ShowGameOverScreen(); // ���������� ����� Game Over, ���� �������� ������ ��� ����� 0
            gameObject.SetActive(false); // ������������ ������ � ���� �������� (��������, ������)
        }
    }

    public void TakeDamage(float damage)
    {
        if (!playerMovement.isInvincible) // ���������, ����������� �� ���� ������������
        {
            HP -= damage; // ��������� �������� �� �������� �����
            UpdateHealthBar(); // ��������� ����������� ��������
        }
    }

    public void RestoreFullHealth()
    {
        HP = 100f; // ��������������� �������� �� ���������
        UpdateHealthBar(); // ��������� ����������� ��������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake") || collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage(5); // ������� ����, ���� ����� ������������ �� ����� ��� ������
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!playerMovement.isInvincible) // ���������, ����������� �� ���� ������������
        {
            if (isFalling && collision.gameObject.CompareTag("ground"))
            {
                isFalling = false; // ���� ����� ������������ � ������ ����� �������, ���������� ���� �������
                float fallDistance = fallStartY - transform.position.y; // ��������� ������ �������

                if (fallDistance > 20f)
                {
                    HP = 0; // ���� ������ ������� ������ 20 ������, �������� ���������� 0
                    ShowGameOverScreen(); // ���������� ����� Game Over
                }
                else if (fallDistance > 10f)
                {
                    TakeDamage(HP / 2); // ���� ������ ������� ������ 10 ������, ������� ���� � ������� �������� �������� ��������
                }
            }
            else if (collision.gameObject.CompareTag("Laser"))
            {
                TakeDamage(95); // ������� ����, ���� ����� ������������ � �������
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isFalling = true; // ������������� ���� �������, ���� ����� ��������� �������� �����
            fallStartY = transform.position.y; // ���������� ��������� ������ �������
        }
    }

    private void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // ���������� ����� Game Over, ���� �� ����������
        }
    }
}
