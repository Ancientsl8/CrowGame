using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objectives : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    private int HP = 100;
    public int MaxHP;
    [SerializeField] public GameObject GameOver;
    private GameController gamer;
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = HP;
        healthBar.SetMaxHP(MaxHP);
        gamer = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy" || collision.transform.tag =="Mugpie")
        { 
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        HP = HP - 25;
        Debug.Log(HP);
        healthBar.SetHealth(HP);
    }

    public void Die()
    {
        gamer.Die();
        Destroy(gameObject);
    }
}
