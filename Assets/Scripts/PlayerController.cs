using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveY;
    private float moveX;
    [SerializeField] float speed;
    Vector3 moveDir;
    private Rigidbody2D rb;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ||| WARNING SPAGHETTI CODE INBOUND AVERT YOUR EYES IF YOU ARE A SEASONED PROGRAMMER! |||
        moveX = 0;
        moveY = 0;

        //Gets movement Input
       if (Input.GetKey(KeyCode.W))
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
        moveDir = new Vector3(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        //moves player
        rb.velocity = moveDir * speed;
    }
}
