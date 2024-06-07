using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HpBar hpBar = collision.GetComponent<HpBar>();
            if (hpBar != null)
            {
                hpBar.TakeDamage(damage);
            }
            // Добавляем эффект взрыва, если необходимо
            Destroy(gameObject);
        }
    }
}
