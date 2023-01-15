using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 ShootDir;
    [SerializeField] private Transform PfPowerUpSpread;
    [SerializeField] private Transform PfPowerUpFireRate;
    [SerializeField] private Transform PfPowerUpSpeed;
    [SerializeField] private Vector3 DropPosition;
    public void Setup(Vector3 ShootDir)
    {
        //Sets the direction of the bullet
        this.ShootDir = ShootDir;
        //Destroys bullet after 3 seconds
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        //Speed of bullet
        float bSpeed = 10f;
        //Bullet moves following set direction
        transform.position += bSpeed * Time.deltaTime * ShootDir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collides with enemy, deletes them.
        if (collision.transform.tag == "Enemy" || collision.transform.tag == "Mugpie")
        {
            Destroy(collision.gameObject);
            DropPosition = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y);
            DropItem(DropPosition);
        }
    }

    void DropItem(Vector3 Boi)
    {
        int DropChance;
        int ItemType;
        ItemType = Random.Range(1, 4);
        DropChance = Random.Range(1, 100);
        if (DropChance > 60)
        {
            if (ItemType == 1)
            {
                Instantiate(PfPowerUpSpread, Boi, Quaternion.identity);
            }
            if (ItemType == 2)
            {
                Instantiate(PfPowerUpSpeed, Boi, Quaternion.identity);
            }
            if (ItemType == 3)
            {
                Instantiate(PfPowerUpFireRate, Boi, Quaternion.identity);
            }
        }
    }
}
