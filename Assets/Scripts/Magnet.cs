using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetDuration = 10f; // Длительность действия магнита

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ActivateMagnet(magnetDuration); // Активируем магнит у игрока
                Destroy(gameObject); // Уничтожаем объект магнита после активации
            }
        }
    }
}
