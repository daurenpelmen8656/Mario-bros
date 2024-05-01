using System.Collections;
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
