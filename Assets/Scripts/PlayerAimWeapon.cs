using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    public Vector3 ShootPosition;
    public Vector3 GunEndPointPosition;
    [SerializeField] private Transform AimGunEndpointTransform;
    [SerializeField] private Transform pfBullet;
    private float nextFire = 0f;
    private float fireRate = 0.4f;
    [SerializeField]private float projectileSpread;
    [SerializeField] private int noOfProjectiles;
    private bool Spreadshot;
    private float timer = 10f;
    private float timer2 = 10f;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        Spreadshot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0 && Spreadshot == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer2 > 0 && fireRate == 0.2f)
        {
            timer2 -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            Spreadshot = false;
            timer = 10;
        }
        if (timer2 <= 0)
        {
            fireRate = 0.4f;
            timer2 = 10;
        }
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        float startRotation = angle + projectileSpread / 2f;
        float angleIncrease = projectileSpread / ((float)noOfProjectiles - 1f);
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetMouseButtonDown(0) && nextFire < Time.time)
        {
            nextFire = Time.time + fireRate;
            Shoot(startRotation, angleIncrease);
        }
    }
    public void PowerUpSpread()
    {
        Spreadshot = true;
    }

    public void PowerUpFireRate()
    {
        fireRate = 0.2f;
    }
    public void Shoot(float x, float y)
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        ShootPosition = mousePosition;
        GunEndPointPosition = AimGunEndpointTransform.position;
        if(Spreadshot == false)
        {
            Transform bulletTransform = Instantiate(pfBullet, GunEndPointPosition, Quaternion.identity);
            Vector3 ShootDir = (ShootPosition - GunEndPointPosition).normalized;
            bulletTransform.GetComponent<Bullet>().Setup(ShootDir);
        }
        else if (Spreadshot == true)
        {
            for (int i = 0; i < noOfProjectiles; i++)
            {
                //where x is = to startRotation, and y is = to angleIncrease
                float tempRot = x - y * i;
                Transform bulletTransform = Instantiate(pfBullet, GunEndPointPosition, Quaternion.identity);
                Vector3 ShootDir = new Vector3(Mathf.Cos(tempRot * Mathf.Deg2Rad), Mathf.Sin(tempRot * Mathf.Deg2Rad));
                bulletTransform.GetComponent<Bullet>().Setup(ShootDir);
            }
        }
       
        
    }
    //Gets mouse positon
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
