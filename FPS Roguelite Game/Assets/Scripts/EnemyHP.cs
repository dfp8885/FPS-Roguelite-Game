using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Animator animator;
    public Material[] eliteMaterials;
    public GameObject body;
    public EnemyAI ai;

    public int maxHealth = 50;
    public int healthMultiplier = 1;
    int currentHealth;

    public HPBar healthBar;
    public bool isElite = false;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        if (isElite) {
            int eliteType = Random.Range(0, eliteMaterials.Length);
            body.GetComponent<MeshRenderer>().material = eliteMaterials[eliteType];
            healthMultiplier = 3;
            ai.setElite(eliteType);
        }

        maxHealth = maxHealth * healthMultiplier;
        currentHealth = maxHealth;
        if (healthBar != null) {
            healthBar.SetMaxHP(maxHealth);
        }
    }

    public bool TakeDamage(int damage, DamageMultiplier multiplier) {
        currentHealth -= damage * multiplier.damageMultiplier;

        if (healthBar != null) {
            healthBar.SetHP(currentHealth);
        }

        if (currentHealth <= 0){
            return Die();
        }
        else {
            return false;
        }
    }

    bool Die() {
        isDead = true;
        Destroy(gameObject);
        return isDead;
    }

    public int getCurrentHealth() {
        return currentHealth;
    }
}
