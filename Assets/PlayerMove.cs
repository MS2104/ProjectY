using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    float speedX, speedY;
    Rigidbody2D rb;

    private bool m_FacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(speedX, speedY);

        // Normalize the movement vector if there is input, then scale by moveSpeed
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        if (speedX > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (speedX < 0 && m_FacingRight)
        {
            Flip();
        }

        rb.velocity = movement * moveSpeed;
    }

    
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0);
    }
}
