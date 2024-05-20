using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5; // Скорость движения игрока
    private Rigidbody2D rb; // Компонент Rigidbody2D для управления физикой
    public float jumph = 5; // Сила прыжка
    private bool isgrounded = false; // Флаг, указывающий, находится ли игрок на земле

    private Animator anim; // Компонент Animator для управления анимацией
    private Vector3 rotation; // Вектор для хранения текущей ориентации объекта

    private CoinManager m; // Ссылка на компонент CoinManager для управления монетами

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
        anim = GetComponent<Animator>(); // Получаем компонент Animator
        rotation = transform.eulerAngles; // Сохраняем текущую ориентацию объекта
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>(); // Находим и сохраняем компонент CoinManager по тегу "Text"
    }

    void Update()
    {
        float richtung = Input.GetAxis("Horizontal"); // Получаем ввод по оси "Horizontal" (влево-вправо)

        if (richtung != 0)
        {
            anim.SetBool("isRunning", true); // Устанавливаем анимацию бега
        }
        else
        {
            anim.SetBool("isRunning", false); // Останавливаем анимацию бега
        }

        if (richtung < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1); // Инвертируем масштаб по оси X для поворота влево
        }
        if (richtung > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1); // Восстанавливаем масштаб по оси X для поворота вправо
        }

        rb.velocity = new Vector2(richtung * speed, rb.velocity.y); // Устанавливаем скорость движения по оси X

        if (!isgrounded)
        {
            anim.SetBool("isJumping", true); // Устанавливаем анимацию прыжка
        }
        else
        {
            anim.SetBool("isJumping", false); // Останавливаем анимацию прыжка
        }

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse); // Добавляем силу для прыжка
            isgrounded = false; // Устанавливаем флаг, что игрок больше не на земле
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isgrounded = true; // Устанавливаем флаг, что игрок на земле
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            m.Addmoney(); // Добавляем монеты
            Destroy(other.gameObject); // Уничтожаем объект фрукта
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Загружаем следующую сцену
        }
    }
}
