using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the rate of fire and bullet speed of a gun.
/// </summary>
public class GunController : MonoBehaviour
{
    public bool isFiring;

   // public BulletController bullet;
   // public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;
    public GameObject gun;
    public GameObject powerUpGun;
    public Transform [] firePoint;

    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                if (gun.activeInHierarchy == true)
                {
                    for (int i = 0; i < firePoint.Length; i++)
                    {
                        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("PlayerBullet");
                        shotCounter = timeBetweenShots;
                        bullet.transform.position = firePoint[i].position;
                        bullet.transform.rotation = firePoint[i].transform.rotation;
                        bullet.SetActive(true);                  
                    }
                }
                if (powerUpGun.activeInHierarchy == true)
                {
                    for (int i = 0; i < firePoint.Length; i++)
                    {
                        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("PlayerPowerUp");
                        shotCounter = timeBetweenShots;
                        bullet.transform.position = firePoint[i].position;
                        bullet.transform.rotation = firePoint[i].transform.rotation;
                        bullet.SetActive(true);
                    }
                }

            }
        }
    
    }
}
