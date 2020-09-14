using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDoubleShot : MonoBehaviour
{

    public GameObject doubleGun;
   // public GameObject defaultGun;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DoubleGunPickUp")
        {
            // defaultGun.SetActive(false);
            doubleGun.GetComponent<GunActiveTimer>().timer += doubleGun.GetComponent<GunActiveTimer>().activeTimer;
            doubleGun.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
