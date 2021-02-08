using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public EnemyRadius radius;
    public GameObject player;
    private void Start() {
        player = GameObject.Find("First Person Player");

    }

    private void Update() {
        if (radius.playerFound) {
            this.GetComponent<Rigidbody>().AddForce((player.transform.position - transform.position).normalized * 50);
        }
    }
}
