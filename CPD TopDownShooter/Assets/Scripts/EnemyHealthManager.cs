using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// Handles damage to the enemy and also particle blood effects on enemy hit and death.
/// </summary>
public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public int scoreValue = 1;
    public GameObject ItemToDrop;
    public GameObject blood;
    public GameObject blood2;
    public GameObject hitBlood;
   

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
            if (gameObject.tag == "HealthZombie" || gameObject.tag == "Boss" || gameObject.tag == "PowerUpZombie")
            {
                var obj = GameObject.Instantiate(ItemToDrop);
                obj.transform.position = transform.position;           
            }
            Instantiate(blood, transform.position, Quaternion.identity);
            Instantiate(blood2, transform.position, Quaternion.identity);
            ScoreManager.score += scoreValue;
            Destroy(gameObject);
        }
    }

    //damage Enemy Object
    public void HurtEnemy(int damage)
    {
        Instantiate(hitBlood, transform.position, Quaternion.identity);
        currentHealth -= damage;
    }
}
