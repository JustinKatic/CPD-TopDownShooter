using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDoubleShot : MonoBehaviour
{

    public GameObject doubleGun;
    public GameObject defaultGun;

    //public float powerUpTime;
    //private float timer;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DoubleGunPickUp")
        {
            defaultGun.SetActive(false);
            doubleGun.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    //private void Update()
    //{
    //    if (timer > 0)
    //    {
    //        timer -= Time.deltaTime;
    //        if (timer <= 0)
    //        {
    //            timer = powerUpTime;
    //            doubleGun.SetActive(false);
    //        }
    //    }
    //}
}
