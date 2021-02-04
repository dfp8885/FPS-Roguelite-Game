using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour{
    public GameObject player;
    public GameObject fireball;
    public EnemyRadius enemyRadius;
    public Transform firePoint;
    public float fireRate = 1f;
    public float fireForce = 500f;

    private float fireRateTime = 0f;


    private void Start() {
        player = GameObject.Find("First Person Player");
    }

    // Update is called once per frame
    void Update() {
        if (enemyRadius.playerFound) {
            // Make enemy follow player
            gameObject.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);

            //make enemy shoot at player
            if (Time.time > fireRateTime) {
                GameObject go = (GameObject)Instantiate(fireball, firePoint.position, firePoint.rotation);
                go.GetComponent<Rigidbody>().AddForce((player.transform.position-firePoint.position).normalized*fireForce);
                fireRateTime = Time.time + 1 / fireRate;
            }
        }
    }
}
