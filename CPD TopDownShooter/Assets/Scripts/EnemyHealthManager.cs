using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    public int currentHealth;

    public GameObject healthPotion;

    void Start()
    {
        //set initial health
        currentHealth = health; 
    }

    void Update()
    {
        //destory object if health <0
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "HealthZombie")
            {
                var obj = GameObject.Instantiate(healthPotion);
                obj.transform.position = transform.position;
            }
            Destroy(gameObject);
        }
    }

    //damage Enemy Object
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
