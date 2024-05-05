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
    private bool hasTakenDamage = false; // Флаг для отслеживания получения урона

    void Start()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        Bar.fillAmount = HP / 100;

        if (HP <= 0)
        {
            // Обработка смерти игрока
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            if (!hasTakenDamage) // Проверяем, не получал ли уже урон игрок
            {
                HP -= 5;
                hasTakenDamage = true; // Устанавливаем флаг, что получен урон
                UpdateHealthBar();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            if (!hasTakenDamage) // Проверяем, не получал ли уже урон игрок
            {
                HP -= 5 * Time.deltaTime; // Уменьшаем здоровье со временем
                hasTakenDamage = true; // Устанавливаем флаг, что получен урон
                UpdateHealthBar();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            hasTakenDamage = false; // Сбрасываем флаг при выходе из зоны урона
        }
    }
}
