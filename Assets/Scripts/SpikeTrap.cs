using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<HpBar>().TakeDamage(15); // Наносим урон игроку
        }
    }
}
