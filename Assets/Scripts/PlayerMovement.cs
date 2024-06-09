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

    public bool hasMagnet = false; // ���������� ��� ��������, �������� �� ����� ������
    public float magnetRadius = 5f; // ������ �������� �������
    public float magnetDuration = 10f; // ������������ �������� �������

    private bool isSpeedBoosted = false; // ���������� ��� ��������, ����������� �� ���� ��������
    public float speedBoostDuration = 5f; // ������������ �������� ����� ��������

    private bool isJumpBoosted = false; // ���������� ��� ��������, ����������� �� ���� ������
    public float jumpBoostDuration = 5f; // ������������ �������� ����� ������
    public float jumpBoostMultiplier = 2f; // ��������� ��� ���������� ������ ������

    public bool isInvincible = false; // ���������� ��� ��������, ����������� �� ���� ������������

    private float moveDirection = 0; // ����������� ��������

    public AudioSource jumpAudio, coinAudio, deathAudio, boostAudio, magnetAudio, fallAudio;

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
            CollectFruits(); // �������� ������, ���� ������ ��������
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
            fallAudio.Play();
            isgrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            if (coinAudio != null)
            {
                coinAudio.Play();
            }
            m.Addmoney();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.gameObject.tag == "Magnet")
        {
            StartCoroutine(ActivateMagnet(magnetDuration)); // ��������� �������� ��� ��������� �������
            Destroy(other.gameObject); // ���������� ������ �������
            if (magnetAudio != null)
            {
                magnetAudio.Play();
            }
        }
        if (other.gameObject.tag == "SpeedBoost")
        {
            StartCoroutine(SpeedBoost()); // ��������� �������� ��� ���������� ��������
            Destroy(other.gameObject); // ���������� ������ ����� ��������
            if (boostAudio != null)
            {
                boostAudio.Play();
            }
        }
        if (other.gameObject.tag == "JumpBoost")
        {
            StartCoroutine(JumpBoost()); // ��������� �������� ��� ���������� ������ ������
            Destroy(other.gameObject); // ���������� ������ ����� ������
            if (boostAudio != null)
            {
                boostAudio.Play();
            }
        }
    }

    IEnumerator SpeedBoost()
    {
        speed *= 2; // ��������� �������� ������
        isSpeedBoosted = true; // ������������� ����, ��� ���� �������� �����������

        yield return new WaitForSeconds(speedBoostDuration); // ���� ��������� �������� �����

        speed /= 2; // ��������������� �������� �������� ������
        isSpeedBoosted = false; // ���������� ���� ����� ��������
    }

    IEnumerator JumpBoost()
    {
        jumph *= jumpBoostMultiplier; // ����������� ������ ������ ������
        isJumpBoosted = true; // ������������� ����, ��� ���� ������ �����������

        yield return new WaitForSeconds(jumpBoostDuration); // ���� ��������� �������� �����

        jumph /= jumpBoostMultiplier; // ��������������� �������� ������ ������
        isJumpBoosted = false; // ���������� ���� ����� ������
    }

    public IEnumerator ActivateInvincibility(float duration)
    {
        isInvincible = true; // ������ ������ ����������
        yield return new WaitForSeconds(duration); // ���� ��������� �������� �����
        isInvincible = false; // ��������������� ����������� �������� ����
    }

    public IEnumerator ActivateMagnet(float duration)
    {
        hasMagnet = true; // �������� ������
        yield return new WaitForSeconds(duration); // ���� ��������� �������� �������
        hasMagnet = false; // ��������� ������
    }

    void CollectFruits()
    {
        Collider2D[] fruits = Physics2D.OverlapCircleAll(transform.position, magnetRadius, LayerMask.GetMask("Fruit"));
        foreach (Collider2D fruit in fruits)
        {
            if (coinAudio != null)
            {
                coinAudio.Play();
            }
            m.Addmoney();
            Destroy(fruit.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, magnetRadius);
    }
}
