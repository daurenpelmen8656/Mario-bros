using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumph = 5;
    private bool isgrounded = false;

    private Animator anim;
    private Vector3 rotation;

    private CoinManager m;

    public bool hasMagnet = false; // Переменная для проверки, подобрал ли игрок магнит
    public float magnetRadius = 5f; // Радиус действия магнита
    public float magnetStrength = 10f; // Сила притяжения

    private bool isSpeedBoosted = false; // Переменная для проверки, активирован ли буст скорости
    public float speedBoostDuration = 5f; // Длительность действия буста скорости

    private float moveDirection = 0; // Направление движения

    public AudioSource jumpAudio, coinAudio, deathAudio, boostAudio, magnetAudio;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>();
    }

    void Update()
    {
        float richtung = Input.GetAxis("Horizontal") + moveDirection;

        if (richtung != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (richtung < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }
        if (richtung > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }

        rb.velocity = new Vector2(richtung * speed, rb.velocity.y);

        if (!isgrounded)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            jumpAudio.Play();
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            isgrounded = false;
        }

        if (hasMagnet)
        {
            AttractFruits(); // Притягиваем фрукты, если магнит подобран
        }
    }

    public void MoveLeft()
    {
        moveDirection = -1;
    }

    public void MoveRight()
    {
        moveDirection = 1;
    }

    public void StopMoving()
    {
        moveDirection = 0;
    }

    public void Jump()
    {
        if (isgrounded)
        {
            jumpAudio.Play();
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            
            isgrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isgrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            coinAudio.Play();
            m.Addmoney();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.gameObject.tag == "Magnet")
        {
            hasMagnet = true; // Устанавливаем флаг, что магнит подобран
            Destroy(other.gameObject); // Уничтожаем объект магнита
        }
        if (other.gameObject.tag == "SpeedBoost")
        {

            StartCoroutine(SpeedBoost()); // Запускаем корутину для увеличения скорости
            Destroy(other.gameObject); // Уничтожаем объект буста скорости
            boostAudio.Play();
        }
    }

    IEnumerator SpeedBoost()
    {
        speed *= 2; // Удваиваем скорость игрока
        isSpeedBoosted = true; // Устанавливаем флаг, что буст скорости активирован

        yield return new WaitForSeconds(speedBoostDuration); // Ждем окончания действия буста

        speed /= 2; // Восстанавливаем исходную скорость игрока
        isSpeedBoosted = false; // Сбрасываем флаг буста скорости
    }

    void AttractFruits()
    {
        Collider2D[] fruits = Physics2D.OverlapCircleAll(transform.position, magnetRadius, LayerMask.GetMask("Fruit"));
        foreach (Collider2D fruit in fruits)
        {
            Vector2 direction = (Vector2)transform.position - (Vector2)fruit.transform.position;
            fruit.GetComponent<Rigidbody2D>().AddForce(direction.normalized * magnetStrength);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, magnetRadius);
    }
}
