using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows damage to the player
/// </summary>
public class PlayerHurt : MonoBehaviour
{
    public int damageToGive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
    }
}
