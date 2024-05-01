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
            Debug.Log("Противник убит");
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
        if (currentTarget < positions.Length) // Проверяем, что текущий индекс находится в пределах массива
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);

            if (transform.position == positions[currentTarget])
            {
                currentTarget++;
            }
        }
        else
        {
            currentTarget = 0; // Если текущий индекс выходит за пределы массива, сбрасываем его на начальное значение
        }
    }

    public int damageAmount = 10; // Урон, который наносит враг
    public delegate void PlayerDamaged(int damage); // Делегат для события нанесения урона игроку
    public static event PlayerDamaged OnPlayerDamaged; // Событие нанесения урона игроку

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Проверяем столкновение с игроком
        {
            // Наносим урон игроку через событие OnPlayerDamaged
            OnPlayerDamaged?.Invoke(damageAmount);

            // Уничтожаем объект врага после столкновения с игроком
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Проверяем столкновение с игроком
        {
            // Выводим сообщение о уничтожении врага при столкновении с игроком через триггер
            Debug.Log("Противник убит");

            // Уничтожаем объект врага после столкновения с игроком через триггер
            Destroy(gameObject);
        }
    }
}
