using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Initialize the bullet with a specific direction
    public void Initialize(Vector2 direction)
    {
        // Set the bullet's velocity in the direction specified
        rb.velocity = direction.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(100);
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
    }
}