using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public int scoreValue = 1;
    public GameObject ItemToDrop;

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
            if (gameObject.tag == "HealthZombie" || gameObject.tag == "Boss")
            {
                var obj = GameObject.Instantiate(ItemToDrop);
                obj.transform.position = transform.position;           
            }
            ScoreManager.score += scoreValue;
            Destroy(gameObject);
        }
    }

    //damage Enemy Object
    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
    }
}
