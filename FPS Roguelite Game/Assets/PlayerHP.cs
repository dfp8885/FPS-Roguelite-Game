using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxShield = 50;
    
    int currentHealth;
    int currentShield;

    public HPBar healthBar;
    public HPBar shieldBar;

    bool shieldInvulnUp = true;
    float shieldInvulnCooldown = 10f;
    float invulnTime = 1f;
    float nextShield;
    float invulnActive;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;

        healthBar.SetMaxHP(maxHealth);
        shieldBar.SetMaxHP(maxShield);
    }

    public void TakeDamage(int damage) {
        // Check if player has invulnerability currently active
        if (Time.time > invulnActive) {
            // Check the cooldown of shield invulnerability
            if (Time.time > nextShield)
            {
                shieldInvulnUp = true;
            }

            // Always send damage to shield first
            currentShield -= damage;
            // Check if the shield has no more hit points and that the cooldown for invulnerability is up
            if (currentShield <= 0 && shieldInvulnUp){
                currentShield = 0;
                invulnActive = Time.time + invulnTime;
                nextShield = Time.time + shieldInvulnCooldown;
                shieldInvulnUp = false;
            }
            else if (currentShield <= 0 && !shieldInvulnUp) {
                int tempDamage = Mathf.Abs(currentShield);
                currentHealth -= tempDamage;
            }

            // Update HP Bars
            healthBar.SetHP(currentHealth);
            shieldBar.SetHP(currentShield);
        }
    }


}
