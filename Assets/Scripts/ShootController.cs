using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] Transform pfBullet;
    [SerializeField] Transform ShootPos;
    Vector2 lookDir, ShootDir;
    float LookAngle;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        ShootPos.rotation = Quaternion.Euler(0, 0, LookAngle);
        Debug.Log(LookAngle);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        ShootDir = ShootPos.right;
        Transform bulletTransform = Instantiate(pfBullet, ShootPos.position, Quaternion.Euler(0, 0, LookAngle));
        bulletTransform.GetComponent<Bullet>().Setup(ShootDir);
    }
}
