using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpShotGun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject defaultGun;
    public GameObject ShotGun;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ShotGun")
        {
            defaultGun.SetActive(false);
            ShotGun.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
