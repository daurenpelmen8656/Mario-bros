using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float speed; // �������� �������� ����
    public Vector3[] positions; // ������ �������, ����� �������� ����� ������������ ����
    private int currentTarget; // ������ ������� ���� � ������� �������
    private bool isFacingRight = true; // ����, �����������, ������� �� ���� ������
    private SpriteRenderer spriteRenderer; // ������ �� ��������� SpriteRenderer

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // ������������� ���������� SpriteRenderer
    }

    void Update()
    {
        if (positions.Length == 0) return; // ��������, ��� ������ ������� �� ����

        if (currentTarget < positions.Length)
        {
            MoveToNextPosition(); // ���������� ���� � ��������� �������
        }
        else
        {
            currentTarget = 0; // ���������� ������, ���� �������� ����� ������� �������
        }
    }

    private void MoveToNextPosition()
    {
        if (currentTarget >= positions.Length) return; // ��������, ��� ������� ������ � �������� �������

        // ���������� ���� � ������� ����
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed * Time.deltaTime);

        if (transform.position == positions[currentTarget])
        {
            currentTarget++; // ��������� � ��������� ����, ���� �������� �������
        }

        // ��������� ����������� �������� � �������������� ������, ���� �����
        if (currentTarget < positions.Length)
        {
            if (transform.position.x > positions[currentTarget].x && isFacingRight)
            {
                FlipSprite();
            }
            else if (transform.position.x < positions[currentTarget].x && !isFacingRight)
            {
                FlipSprite();
            }
        }
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight; // ������ �����������
        Vector3 newScale = transform.localScale;
        newScale.x *= -1; // �������� ������ �� �����������
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<HpBar>().TakeDamage(10); // ������� ���� ������ ��� ������������
        }
    }
}
