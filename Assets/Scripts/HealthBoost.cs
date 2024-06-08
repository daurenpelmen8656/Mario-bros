using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HpBar hpBar = other.GetComponent<HpBar>();
            if (hpBar != null)
            {
                hpBar.RestoreFullHealth();
            }
            Destroy(gameObject); // ”ничтожаем объект хила после использовани€
        }
    }
}
