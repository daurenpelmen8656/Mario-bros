using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5; // �������� �������� ������
    private Rigidbody2D rb; // ��������� Rigidbody2D ��� ���������� �������
    public float jumph = 5; // ���� ������
    private bool isgrounded = false; // ����, �����������, ��������� �� ����� �� �����

    private Animator anim; // ��������� Animator ��� ���������� ���������
    private Vector3 rotation; // ������ ��� �������� ������� ���������� �������

    private CoinManager m; // ������ �� ��������� CoinManager ��� ���������� ��������

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
        anim = GetComponent<Animator>(); // �������� ��������� Animator
        rotation = transform.eulerAngles; // ��������� ������� ���������� �������
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>(); // ������� � ��������� ��������� CoinManager �� ���� "Text"
    }

    void Update()
    {
        float richtung = Input.GetAxis("Horizontal"); // �������� ���� �� ��� "Horizontal" (�����-������)

        if (richtung != 0)
        {
            anim.SetBool("isRunning", true); // ������������� �������� ����
        }
        else
        {
            anim.SetBool("isRunning", false); // ������������� �������� ����
        }

        if (richtung < 0)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1); // ����������� ������� �� ��� X ��� �������� �����
        }
        if (richtung > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1); // ��������������� ������� �� ��� X ��� �������� ������
        }

        rb.velocity = new Vector2(richtung * speed, rb.velocity.y); // ������������� �������� �������� �� ��� X

        if (!isgrounded)
        {
            anim.SetBool("isJumping", true); // ������������� �������� ������
        }
        else
        {
            anim.SetBool("isJumping", false); // ������������� �������� ������
        }

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse); // ��������� ���� ��� ������
            isgrounded = false; // ������������� ����, ��� ����� ������ �� �� �����
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isgrounded = true; // ������������� ����, ��� ����� �� �����
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            m.Addmoney(); // ��������� ������
            Destroy(other.gameObject); // ���������� ������ ������
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // ��������� ��������� �����
        }
    }
}
