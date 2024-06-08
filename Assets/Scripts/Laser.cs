using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;
    public float damage = 10f;
    public float duration = 2f; // ������������ ������������� ������

    void Start()
    {
        Destroy(gameObject, duration); // ���������� ����� ����� �������� �����
    }

    void Update()
    {
        // ���������, ��� ����� �������� � ���������� �����������
        transform.Translate(Vector2.left * speed * Time.deltaTime); // �������� ������
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
