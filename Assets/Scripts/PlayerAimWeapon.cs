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

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log(angle);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Yes");
            Shoot();
        }
    }

    public void Shoot()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        ShootPosition = mousePosition;
        GunEndPointPosition = AimGunEndpointTransform.position;
        Transform bulletTransform = Instantiate(pfBullet, GunEndPointPosition, Quaternion.identity);
        Vector3 ShootDir = (ShootPosition - GunEndPointPosition).normalized;
        bulletTransform.GetComponent<Bullet>().Setup(ShootDir);
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
