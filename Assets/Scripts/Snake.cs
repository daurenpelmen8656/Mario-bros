using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float speed; // Скорость движения змеи
    public Vector3[] positions; // Массив позиций, между которыми будет перемещаться змея
    private int currentTarget; // Индекс текущей цели в массиве позиций
    private bool isFacingRight = true; // Флаг, указывающий, смотрит ли змея вправо
    private SpriteRenderer spriteRenderer; // Ссылка на компонент SpriteRenderer

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Инициализация компонента SpriteRenderer
    }

    void Update()
    {
        if (positions.Length == 0) return; // Проверка, что массив позиций не пуст

        if (currentTarget < positions.Length)
        {
            MoveToNextPosition(); // Перемещаем змею к следующей позиции
        }
        else
        {
            currentTarget = 0; // Сбрасываем индекс, если достигли конца массива позиций
        }
    }

    private void MoveToNextPosition()
    {
        if (currentTarget >= positions.Length) return; // Проверка, что текущий индекс в пределах массива

        // Перемещаем змею к текущей цели
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed * Time.deltaTime);

        if (transform.position == positions[currentTarget])
        {
            currentTarget++; // Переходим к следующей цели, если достигли текущей
        }

        // Проверяем направление движения и переворачиваем спрайт, если нужно
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
        isFacingRight = !isFacingRight; // Меняем направление
        Vector3 newScale = transform.localScale;
        newScale.x *= -1; // Отражаем спрайт по горизонтали
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<HpBar>().TakeDamage(10); // Наносим урон игроку при столкновении
        }
    }
}
