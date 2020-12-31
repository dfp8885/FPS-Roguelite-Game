using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadius : MonoBehaviour
{
    public Transform enemyGFX;
    public float rangeRadius = 60f;
    public LayerMask playerLayers;
    public bool playerFound = false;

    // Update is called once per frame
    void LateUpdate()
    {
        Collider[] foundColliders = Physics.OverlapSphere(enemyGFX.position, rangeRadius, playerLayers);

        foreach (Collider coll in foundColliders) {
            playerFound = true;
        }
    }
}
