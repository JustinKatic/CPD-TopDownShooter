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
    //public GameObject blood;
    //public GameObject blood2;
    //public GameObject hitBlood;


    private void OnEnable()
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
            GameObject blood = ObjectPooler.SharedInstance.GetPooledObject("Blood");
            blood.transform.position = transform.position;
            blood.transform.rotation = Quaternion.identity;
            blood.SetActive(true);

            GameObject blood3 = ObjectPooler.SharedInstance.GetPooledObject("ZombieBloodSplash");
            blood3.transform.position = transform.position;
            blood3.transform.rotation = Quaternion.identity;
            blood3.SetActive(true);

            if (gameObject.tag == "Giant")
            {
                GameObject blood2 = ObjectPooler.SharedInstance.GetPooledObject("Blood2");
                blood2.transform.position = transform.position;
                blood2.transform.rotation = Quaternion.identity;
                blood2.SetActive(true);
             
                blood3.transform.position = transform.position;
                blood3.transform.rotation = Quaternion.identity;
                blood3.SetActive(true);
            }
   
            //add score
            ScoreManager.score += scoreValue;

            //set zombie to false
            gameObject.SetActive(false);
        }
    }

    //damage Enemy Object
    public void HurtEnemy(int damage)
    {
        GameObject hitBlood = ObjectPooler.SharedInstance.GetPooledObject("HitBlood");
        hitBlood.transform.position = transform.position;
        hitBlood.transform.rotation = Quaternion.identity;
        hitBlood.SetActive(true);
       // Instantiate(hitBlood, transform.position, Quaternion.identity);
        currentHealth -= damage;
    }
}
