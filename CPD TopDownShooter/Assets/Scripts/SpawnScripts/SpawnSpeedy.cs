using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpeedy : MonoBehaviour
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

		int spawnPointIndex = Random.Range(0, spawnPoints.Length);                                          // Find a random index between zero and one less than the number of spawn points.

		Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);   // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
	}
}
