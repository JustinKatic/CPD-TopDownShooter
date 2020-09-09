using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objToSpawn;

    public float spawninSeconds = 3.0f;
    private float SpawnCooldown = 0.0f;

    void Start()
    {
        SpawnCooldown = spawninSeconds;
    }

    void Update()
    {
        //objToSpawn.SetActive(true);
        SpawnCooldown -= Time.deltaTime;
        if(SpawnCooldown < 0)
        {
            SpawnCooldown = spawninSeconds;
            var obj = GameObject.Instantiate(objToSpawn);
            obj.transform.position = transform.position;
        }
    }
}
