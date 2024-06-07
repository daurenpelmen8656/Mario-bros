using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetRadius = 5f; // Радиус действия магнита
    public float magnetStrength = 10f; // Сила притяжения

    void Update()
    {
        AttractFruits();
    }

    void AttractFruits()
    {
        Collider2D[] fruits = Physics2D.OverlapCircleAll(transform.position, magnetRadius, LayerMask.GetMask("Fruit"));
        Debug.Log("Fruits found: " + fruits.Length);
        foreach (Collider2D fruit in fruits)
        {
            Vector2 direction = (Vector2)transform.position - (Vector2)fruit.transform.position;
            fruit.GetComponent<Rigidbody2D>().AddForce(direction.normalized * magnetStrength);
            Debug.Log("Attracting fruit: " + fruit.name);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, magnetRadius);
    }
}
