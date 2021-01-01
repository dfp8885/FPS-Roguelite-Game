using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;

    Shooting gun;
    bool killed;

    bool hit = false;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, 3f);
    }


    private void OnCollisionEnter(Collision collision) {
        if (!hit) {
            EnemyHP enemyHP = collision.collider.GetComponentInParent<EnemyHP>();
            DamageMultiplier multiplier = collision.collider.GetComponent<DamageMultiplier>();

            if (enemyHP != null)
            {
                // Deal damage to enemy hit
                killed = enemyHP.TakeDamage(damage, multiplier);
                // Notify the gun that an enemy has been hit
                gun.objectHit(multiplier.crit);
                // If the bullet killed an enemy notify the gun to keep track
                if (killed)
                {
                    gun.incrementKills(enemyHP.healthMultiplier);
                }
            }

            Destroy(gameObject);
        }
        hit = true;
    }

    public void setGun(Shooting gun) {
        this.gun = gun;
    }

}
