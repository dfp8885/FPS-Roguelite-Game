using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 50;
    int currentHealth;

    public HPBar healthBar;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null) {
            healthBar.SetMaxHP(maxHealth);
        }
    }

    public void TakeDamage(int damage, DamageMultiplier multiplier) {
        currentHealth -= damage * multiplier.damageMultiplier;

        if (healthBar != null) {
            healthBar.SetHP(currentHealth);
        }

        if (currentHealth == 0) { Die(); }
    }

    void Die() {
        isDead = true;

        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }
}
