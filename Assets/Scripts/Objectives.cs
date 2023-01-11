using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    private int HP = 100;
    public int MaxHP;
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = HP;
        healthBar.SetMaxHP(MaxHP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        { 
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        this.HP = HP - 25;
        Debug.Log(HP);
        healthBar.SetHealth(HP);
    }
}
