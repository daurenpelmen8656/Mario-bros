/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public delegate void SnakeCollision();

    public static event SnakeCollision OnSnakeCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject); 
        }

        if (collision.gameObject.tag == "Snake")
        {
            OnSnakeCollision?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("��������� ����");
            Destroy(gameObject); 
        }
    }
}
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3[] positions;
    private int currentTarget;

    public void FixedUpdate()
    {
        if (currentTarget < positions.Length) // ���������, ��� ������� ������ ��������� � �������� �������
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);

            if (transform.position == positions[currentTarget])
            {
                currentTarget++;
            }
        }
        else
        {
            currentTarget = 0; // ���� ������� ������ ������� �� ������� �������, ���������� ��� �� ��������� ��������
        }
    }

    public int damageAmount = 10; // ����, ������� ������� ����
    public delegate void PlayerDamaged(int damage); // ������� ��� ������� ��������� ����� ������
    public static event PlayerDamaged OnPlayerDamaged; // ������� ��������� ����� ������

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // ��������� ������������ � �������
        {
            // ������� ���� ������ ����� ������� OnPlayerDamaged
            OnPlayerDamaged?.Invoke(damageAmount);

            // ���������� ������ ����� ����� ������������ � �������
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // ��������� ������������ � �������
        {
            // ������� ��������� � ����������� ����� ��� ������������ � ������� ����� �������
            Debug.Log("��������� ����");

            // ���������� ������ ����� ����� ������������ � ������� ����� �������
            Destroy(gameObject);
        }
    }
}
