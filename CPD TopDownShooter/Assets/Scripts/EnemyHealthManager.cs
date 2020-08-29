using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    public int currentHealth;

    void Start()
    {
        //set initial health
        currentHealth = health; 
    }

    void Update()
    {
        //destory object if health <0
        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    //damage Enemy Object
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
