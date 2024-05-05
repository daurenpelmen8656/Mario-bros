/*using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float HP = 100f;
    public Image Bar;

    void Start()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        Bar.fillAmount = HP / 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            HP -= 5;
            UpdateHealthBar();
        }
    }
}*/


using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float HP = 100f;
    public Image Bar;
    private bool hasTakenDamage = false; // ���� ��� ������������ ��������� �����

    void Start()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        Bar.fillAmount = HP / 100;

        if (HP <= 0)
        {
            // ��������� ������ ������
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            if (!hasTakenDamage) // ���������, �� ������� �� ��� ���� �����
            {
                HP -= 5;
                hasTakenDamage = true; // ������������� ����, ��� ������� ����
                UpdateHealthBar();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            if (!hasTakenDamage) // ���������, �� ������� �� ��� ���� �����
            {
                HP -= 5 * Time.deltaTime; // ��������� �������� �� ��������
                hasTakenDamage = true; // ������������� ����, ��� ������� ����
                UpdateHealthBar();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            hasTakenDamage = false; // ���������� ���� ��� ������ �� ���� �����
        }
    }
}
