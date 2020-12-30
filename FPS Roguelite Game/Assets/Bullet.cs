using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;

    Shooting gun;
    bool killed;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, 3f);
    }


    private void OnCollisionEnter(Collision collision){
        EnemyHP enemyHP = collision.collider.GetComponentInParent<EnemyHP>();
        DamageMultiplier multiplier = collision.collider.GetComponent<DamageMultiplier>();


        if (enemyHP != null) {
            killed = enemyHP.TakeDamage(damage, multiplier);
            gun.objectHit();
            if (killed) {
                gun.incrementKills();
            }
        }

        Destroy(gameObject);
    }

    public void setGun(Shooting gun) {
        this.gun = gun;
    }

}
