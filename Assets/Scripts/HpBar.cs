using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private float HP = 100f;
    public Image Bar;
    public GameObject gameOverScreen; // Ссылка на объект экрана Game Over

    void Start()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        Bar.fillAmount = HP / 100;

        if (HP <= 0)
        {
            ShowGameOverScreen(); // Показываем экран Game Over при смерти игрока
            gameObject.SetActive(false); // Выключаем объект с здоровьем игрока
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
            TakeDamage(5); // Наносим урон при столкновении с змеей или шипами
        }
    }

    private void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // Активируем экран Game Over
        }
    }
}



