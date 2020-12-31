using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform enemyGFX;
    public Transform cam;
    public Canvas health;
    public LayerMask playerLayers;
    public float rangeRadius = 60f;

    private void Start() {
        cam = GameObject.Find("First Person Player/Main Camera").GetComponent<Transform>();
    }

    void LateUpdate() {
        Collider[] foundColliders = Physics.OverlapSphere(enemyGFX.position, rangeRadius, playerLayers);
        bool playerFound = false;

        foreach (Collider coll in foundColliders)
        {
            playerFound = true;
        }

        if (playerFound) {
            if (!health.enabled) {
                health.enabled = true;
            }
            transform.LookAt(transform.position + cam.forward);
        }
        else if (health.enabled == true) { health.enabled = false; }
    }
}
