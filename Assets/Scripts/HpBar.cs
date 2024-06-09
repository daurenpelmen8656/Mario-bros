using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float HP = 100f; // Переменная для хранения текущего здоровья
    public Image Bar; // UI элемент для отображения здоровья
    public GameObject gameOverScreen; // Ссылка на объект экрана Game Over

    private float fallStartY; // Переменная для отслеживания начальной высоты падения
    private bool isFalling; // Флаг для проверки, падает ли игрок

    private PlayerMovement playerMovement; // Ссылка на скрипт PlayerMovement для проверки щита

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); // Получаем ссылку на скрипт PlayerMovement
        UpdateHealthBar(); // Обновляем отображение здоровья в начале
    }

    void UpdateHealthBar()
    {
        Bar.fillAmount = HP / 100; // Обновляем значение шкалы здоровья

        if (HP <= 0)
        {
            ShowGameOverScreen(); // Показываем экран Game Over, если здоровье меньше или равно 0
            gameObject.SetActive(false); // Деактивируем объект с этим скриптом (например, игрока)
        }
    }

    public void TakeDamage(float damage)
    {
        if (!playerMovement.isInvincible) // Проверяем, активирован ли буст неуязвимости
        {
            HP -= damage; // Уменьшаем здоровье на величину урона
            UpdateHealthBar(); // Обновляем отображение здоровья
        }
    }

    public void RestoreFullHealth()
    {
        HP = 100f; // Восстанавливаем здоровье до максимума
        UpdateHealthBar(); // Обновляем отображение здоровья
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake") || collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage(5); // Наносим урон, если игрок сталкивается со змеей или шипами
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!playerMovement.isInvincible) // Проверяем, активирован ли буст неуязвимости
        {
            if (isFalling && collision.gameObject.CompareTag("ground"))
            {
                isFalling = false; // Если игрок сталкивается с землей после падения, сбрасываем флаг падения
                float fallDistance = fallStartY - transform.position.y; // Вычисляем высоту падения

                if (fallDistance > 20f)
                {
                    HP = 0; // Если высота падения больше 20 единиц, здоровье становится 0
                    ShowGameOverScreen(); // Показываем экран Game Over
                }
                else if (fallDistance > 10f)
                {
                    TakeDamage(HP / 2); // Если высота падения больше 10 единиц, наносим урон в размере половины текущего здоровья
                }
            }
            else if (collision.gameObject.CompareTag("Laser"))
            {
                TakeDamage(95); // Наносим урон, если игрок сталкивается с лазером
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isFalling = true; // Устанавливаем флаг падения, если игрок перестает касаться земли
            fallStartY = transform.position.y; // Запоминаем начальную высоту падения
        }
    }

    private void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // Активируем экран Game Over, если он установлен
        }
    }
}
