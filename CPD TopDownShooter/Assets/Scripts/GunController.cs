using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the rate of fire and bullet speed of a gun.
/// </summary>
public class GunController : MonoBehaviour
{
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;
    public float timeBetweenShots;
    private float shotCounter;

    public Transform [] firePoint;

    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                for (int i = 0; i < firePoint.Length; i++)
                {
                    shotCounter = timeBetweenShots;
                    BulletController newBullet = Instantiate(bullet, firePoint[i].position, firePoint[i].rotation) as BulletController;
                    newBullet.speed = bulletSpeed;
                }
            }
        }
    
    }
}
