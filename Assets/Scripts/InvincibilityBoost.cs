using System.Collections;
using UnityEngine;

public class InvincibilityBoost : MonoBehaviour
{
    public float invincibilityDuration = 5f; // ƒлительность действи€ буста неу€звимости

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                StartCoroutine(player.ActivateInvincibility(invincibilityDuration));
                Destroy(gameObject); // ”ничтожаем объект буста после активации
            }
        }
    }
}
