/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3[] positions;
    private int currentTarget;
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (currentTarget < positions.Length)
        {
            MoveToNextPosition();
        }
        else
        {
            currentTarget = 0;
        }
    }

    private void MoveToNextPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed * Time.deltaTime);

        if (transform.position == positions[currentTarget])
        {
            currentTarget++;
        }

        if (transform.position.x > positions[currentTarget].x && isFacingRight)
        {
            FlipSprite();
        }
        else if (transform.position.x < positions[currentTarget].x && !isFacingRight)
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    public int damageAmount = 10;
    public delegate void PlayerDamaged(int damage);
    public static event PlayerDamaged OnPlayerDamaged;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerDamaged?.Invoke(damageAmount);
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
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (currentTarget < positions.Length)
        {
            MoveToNextPosition();
        }
        else
        {
            currentTarget = 0;
        }
    }

    private void MoveToNextPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed * Time.deltaTime);

        if (transform.position == positions[currentTarget])
        {
            currentTarget++;
        }

        if (transform.position.x > positions[currentTarget].x && isFacingRight)
        {
            FlipSprite();
        }
        else if (transform.position.x < positions[currentTarget].x && !isFacingRight)
        {
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    public int damageAmount = 10;
    public delegate void PlayerDamaged(int damage);
    public static event PlayerDamaged OnPlayerDamaged;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerDamaged?.Invoke(damageAmount);
        }
    }
}

