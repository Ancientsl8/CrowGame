using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public Animator anim;
    public float speed = 5f;
    private Vector2 movementInput;
    PlayerAimWeapon playerAim;
    public GameObject pauseMenu;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerAim = GetComponent<PlayerAimWeapon>();
    }
    void Start()
    {
        Time.timeScale = 1f;
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

        if (Input.GetKeyDown(KeyCode.Escape)){ PauseMenu(); }

    }

    private void Move()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal"); //key inputs (could be WASD or arrow keys)
        movementInput.y = Input.GetAxisRaw("Vertical");
        
        rb.velocity = movementInput * speed * Time.fixedDeltaTime; //moves player
    }

    private void Animate()
    {
        anim.SetFloat("MovementX", movementInput.x);
        anim.SetFloat("MovementY", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
    }

    //PowerUpSystem
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spread")
        {
            Destroy(collision.gameObject);
            playerAim.PowerUpSpread();
        }

        if (collision.gameObject.tag == "Speed")
        {
            Destroy(collision.gameObject);
            speed = 350f;
        }
        if (collision.gameObject.tag == "FireRate")
        {
            Destroy(collision.gameObject);
            playerAim.PowerUpFireRate();
        }
    }

    //Pause Menu
    public void PauseMenu(){
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void BackToMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
