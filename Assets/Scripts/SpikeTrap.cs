using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    // Метод, который вызывается, когда другой коллайдер находится в триггере
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<HpBar>().TakeDamage(15); // Наносим урон игроку
        }
    }
}
    