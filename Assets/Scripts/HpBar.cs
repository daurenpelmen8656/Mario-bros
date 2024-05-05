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
    public GameOverScreen GameOverScreen; // Ссылка на экран Game Over

    void Start()
    {
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        Bar.fillAmount = HP / 100;

        // Проверяем, если здоровье игрока меньше или равно нулю, вызываем GameOver
        if (HP <= 0)
        {
            if (GameOverScreen != null)
            {
                GameOverScreen.Setup(); // Вызываем метод Setup на экране Game Over
            }
            else
            {
                Debug.LogError("GameOverScreen is not assigned!");
            }
        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        UpdateHealthBar();
    }
}