using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    public Canvas health;
    public EnemyRadius enemyRadius;

    private void Start() {
        cam = GameObject.Find("First Person Player/Main Camera").GetComponent<Transform>();
    }

    void LateUpdate() {
        

        if (enemyRadius.playerFound) {
            if (!health.enabled) {
                health.enabled = true;
            }
            transform.LookAt(transform.position + cam.forward);

        }
        else if (health.enabled == true) { health.enabled = false; }
    }
}
