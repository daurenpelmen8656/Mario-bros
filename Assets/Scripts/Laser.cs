using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 10f;
    public float duration = 2f; // Длительность существования лазера

    void Start()
    {
        Destroy(gameObject, duration); // Уничтожаем лазер через заданное время
    }

    void Update()
    {
        // Убедитесь, что лазер движется в правильном направлении
        transform.Translate(Vector2.left * speed * Time.deltaTime); // Движение вправо
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
            Destroy(gameObject);
        }
    }
}
