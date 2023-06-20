using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   //Variables 
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    private bool isRunning = false;
    private bool isJumping = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   void FixedUpdate()
    {   //El jugador inicia a correr cuando se le da click a cualquier parte de la pantalla 
        if (Input.GetMouseButtonDown(0))
        {
            isRunning = true;
        }

        if (isRunning)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        //Salto del jugador 
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}



