using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{
    public bool isFiring;
    public float timeBetweenShots;
    private float shotCounter;

    public Transform[] firePoint;

    void Update()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                for (int i = 0; i < firePoint.Length; i++)
                {
                    GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("EnemyBullet");
                    shotCounter = timeBetweenShots;
                    bullet.transform.position = firePoint[i].position;
                    bullet.transform.rotation = firePoint[i].transform.rotation;
                    bullet.SetActive(true);

                }

            }
        }
    }
}

