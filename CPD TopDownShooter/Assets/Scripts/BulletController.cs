using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls bullet speed, direction, lifetime and damage.
/// </summary>
public class BulletController : MonoBehaviour
{
    public float speed;
    public int damageToGive;


 
    void Update()
    {
        //Move bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    //If collision with enemy deal damage to enemy and destory bullet
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallZombie" || collision.gameObject.tag == "MediumZombie" ||
            collision.gameObject.tag == "SpeedyZombie" || collision.gameObject.tag == "Giant" ||
            collision.gameObject.tag == "GunZombie" || collision.gameObject.tag == "HealthZombie" ||
            collision.gameObject.tag == "Boss" || collision.gameObject.tag == "PowerUpZombie")
        {
            collision.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
            gameObject.SetActive(false);
        }    
        if (collision.gameObject.tag == "Wall")
        {
            gameObject.SetActive(false);
        }
    }

}
