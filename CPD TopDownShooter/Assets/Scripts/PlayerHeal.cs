using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows the player to be healed
/// </summary>
public class PlayerHeal : MonoBehaviour
{
    public int healAmount;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
}
