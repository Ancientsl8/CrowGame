using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] float speed;
    private Vector2 movementInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ||| WARNING SPAGHETTI CODE INBOUND AVERT YOUR EYES IF YOU ARE A SEASONED PROGRAMMER! |||
        //moveX = 0;
        //moveY = 0;

        //Gets movement Input
       /*if (Input.GetKey(KeyCode.W))
        {
            moveY = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1;
        }
        //Moves Player
        //moveDir = new Vector3(moveX, moveY).normalized;*/
        Move();
        Animate();
    }

    private void Move()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal"); //key inputs (could be WASD or arrow keys)
        float Vertical = Input.GetAxisRaw("Vertical");

        if (Horizontal == 0 && Vertical == 0)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        movementInput = new Vector2(Horizontal, Vertical);
        rb.velocity = movementInput * speed * Time.fixedDeltaTime; //moves player
    }

    private void Animate()
    {
        anim.SetFloat("MovementX", movementInput.x);
        anim.SetFloat("MovementY", movementInput.y);
    }
}
