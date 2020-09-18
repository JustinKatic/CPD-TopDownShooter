using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGunZombie : MonoBehaviour
{
	public GameObject enemy;
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

	void Start()
	{
		InvokeRepeating("Spawn", spawnTime, spawnTime);     // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
	}

	void Spawn()
	{
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);       // Find a random index between zero and one less than the number of spawn points.
                                        
		GameObject zombie = ObjectPooler.SharedInstance.GetPooledObject("GunZombie");
		zombie.transform.position = spawnPoints[spawnPointIndex].position;
		zombie.transform.rotation = spawnPoints[spawnPointIndex].transform.rotation;
		zombie.SetActive(true);
	}
}
