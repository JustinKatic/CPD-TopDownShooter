using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the enemy movement and targets them at the player.
/// </summary>
public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;

    //ref to player
    public PlayerController thePlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //finds ref of player by looking for object with PlayerController Script on it
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        //make enemy face the players direction
        transform.LookAt(thePlayer.transform.position);
    }

    private void FixedUpdate()
    {
        //move enemy forward
        rb.velocity = transform.forward * moveSpeed;
    }
}
