using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 ShootDir;
  public void Setup(Vector3 ShootDir)
    {
        //Sets the direction of the bullet
        this.ShootDir = ShootDir;
        //Destroys bullet after 5 seconds
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        //Speed of bullet
        float bSpeed = 10f;
        //Bullet moves following set direction
        transform.position += bSpeed * Time.deltaTime * ShootDir;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //if collides with enemy, deletes them.
        if (col.transform.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
