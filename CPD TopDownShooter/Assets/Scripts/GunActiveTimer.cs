using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls how long the gun is active.
/// </summary>
public class GunActiveTimer : MonoBehaviour
{
    public float activeTimer;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = activeTimer;
            gameObject.SetActive(false);
        }
    }
}
