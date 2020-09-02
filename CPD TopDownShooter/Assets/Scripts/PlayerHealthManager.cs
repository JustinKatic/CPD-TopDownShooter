using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;

    public float flashLength;
    private float flashCounter;

    private Renderer rend;
    private Color storedColor;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rend = GetComponent<Renderer>();
        storedColor = rend.material.GetColor("_Color");
    }


    void Update()
    {
        if (currentHealth <= 0)
            gameObject.SetActive(false);

        if (flashCounter > 0)
            flashCounter -= Time.deltaTime;

        if (flashCounter <= 0)
            rend.material.SetColor("_Color", storedColor);

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
    public void HurtPlayer(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        flashCounter = flashLength;
        rend.material.SetColor("_Color", Color.white);
    }

    public void HealPlayer(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }
}
