using UnityEngine;

public class TimeBoost : MonoBehaviour
{
    public float additionalTime = 30f; // Количество дополнительных секунд

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TimerController timerController = FindObjectOfType<TimerController>();
            if (timerController != null)
            {
                timerController.AddTime(additionalTime);
            }
            Destroy(gameObject); // Уничтожаем объект буста после использования
        }
    }
}
