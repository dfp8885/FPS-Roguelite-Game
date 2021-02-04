using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage = 10;

    bool hit = false;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision) {
        if (!hit) {
            PlayerHP playerHP = collision.collider.GetComponentInParent<PlayerHP>();

            if (playerHP != null) {
                // Deal damage to player hit
                playerHP.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
        hit = true;
    }

}
