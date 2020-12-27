using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 200;
    public int maxShield = 100;
    
    int currentHealth;
    int currentShield;

    public HPBar healthBar;
    public HPBar shieldBar;

    public CooldownTimer shieldCooldown;

    bool recoveredFromFull = true;
    float invulnTime = 1f;
    float invulnActive;

    float shieldRechargeDelay = 5f;
    int shieldRechargeRate = 1;
    float shieldRechargeTick = 0.05f;
    float nextUpdate;
    float nextRecharge;
    

    // Start is called before the first frame update
    void Start(){
        currentHealth = maxHealth;
        currentShield = maxShield;

        healthBar.SetMaxHP(maxHealth);
        shieldBar.SetMaxHP(maxShield);

        nextRecharge = Time.time;
        nextUpdate = Time.time + shieldRechargeTick;
    }

    void Update(){
        if (currentShield < maxShield && Time.time > nextRecharge && Time.time > nextUpdate) {
            RechargeShield(shieldRechargeRate);
            nextUpdate = Time.time + shieldRechargeTick;
        }

        shieldCooldown.SetTimer(nextRecharge - Time.time);
    }

    public void TakeDamage(int damage) {
        // Check if player has invulnerability currently active
        if (Time.time > invulnActive) {

            // Always send damage to shield first
            currentShield -= damage;
            // Check if the shield has no more hit points and that the cooldown for invulnerability is up
            if (currentShield <= 0 && recoveredFromFull){
                currentShield = 0;
                invulnActive = Time.time + invulnTime;
                recoveredFromFull = false;
            }
            else if (currentShield <= 0 && !recoveredFromFull) {
                int tempDamage = Mathf.Abs(currentShield);
                currentHealth -= tempDamage;
            }

            // Update Recharge Delay
            nextRecharge = Time.time + shieldRechargeDelay;

            // Update HP Bars
            healthBar.SetHP(currentHealth);
            shieldBar.SetHP(currentShield);
        }
    }

    public void RechargeShield(int amount) {
        currentShield += amount;
        shieldBar.SetHP(currentShield);
        if (currentShield == maxShield) { recoveredFromFull = true; }
    }

    public void Heal(int amount) {
        currentHealth += amount;
        healthBar.SetHP(currentHealth);
    }


}
