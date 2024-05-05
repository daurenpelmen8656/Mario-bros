using UnityEngine;
using UnityEngine.UI;

public class SpikeTrap : MonoBehaviour
{
    private static float HP = 100f; // Сделали переменную статической для всех SpikeTrap
    private float damageRate = 15f; // Урон в единицу времени
    public Image Bar;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HP -= damageRate * Time.deltaTime; // Уменьшаем общее здоровье по мере времени
            Bar.fillAmount = HP / 100;

            // Добавьте здесь проверку, если HP меньше или равно 0, то что-то делаем (например, деактивируем ловушку)
            if (HP <= 0)
            {
                gameObject.SetActive(false); // Деактивируем ловушку
            }
        }
    }
}
