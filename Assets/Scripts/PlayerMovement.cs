using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    public float jumph = 5;
    private bool isgrounded = false;

    private Animator anim;
    private Vector3 rotation;

    private CoinManager m;

    public GameOverScreen GameOverScreen;
    int maxPlatform = 0;

    public void GameOver()
    {
        if (GameOverScreen != null)
        {
            GameOverScreen.Setup(maxPlatform);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>();  
    }

    void Update()
    {
        float richtung = Input.GetAxis("Horizontal");

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
            transform.localScale = new Vector3(-1.5f, 1.5f, 1); // Увеличить масштаб по оси X и Y
        }
        if (richtung > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1); // Увеличить масштаб по оси X и Y
        }

        rb.velocity = new Vector2(richtung * speed, rb.velocity.y);

        if(isgrounded == false)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
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
            m.Addmoney();
            Destroy(other.gameObject);
        }
    }
}
