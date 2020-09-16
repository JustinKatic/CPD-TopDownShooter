using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets the double gun to active when the power up is collected.
/// </summary>
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
