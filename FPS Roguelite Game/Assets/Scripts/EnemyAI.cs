using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    public GameObject player, fireball, fireballHoming, fireballLarge, fireballSmall;
    public EnemyRadius enemyRadius;
    public Transform firePoint;
    public float fireRate = 1f;
    public float fireForce = 500f;

    public float numShots = 1f;
    public float spreadAngle = 2f;

    public bool isElite = false;
    public int eliteType;

    private float fireRateTime = 0f;

    private void Start() {
        player = GameObject.Find("First Person Player");
    }

    // Update is called once per frame
    void Update() {
        if (enemyRadius.playerFound) {
            // Make enemy follow player
            gameObject.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);

            var qAngle = Quaternion.AngleAxis(numShots / 2 * spreadAngle, firePoint.up) * firePoint.rotation;
            var qDelta = Quaternion.AngleAxis(spreadAngle, firePoint.up);

            //make enemy shoot at player
            if (Time.time > fireRateTime) {
                if (numShots == 1) {
                    GameObject go = (GameObject)Instantiate(fireball, firePoint.position, qAngle);
                    go.GetComponent<Rigidbody>().AddForce((player.transform.position - firePoint.position).normalized * fireForce);
                }
                else {
                    for (int i = 0; i < numShots; i++) {
                        GameObject go = (GameObject)Instantiate(fireball, firePoint.position, qAngle);
                        go.GetComponent<Rigidbody>().AddForce(go.transform.forward * fireForce);
                        qAngle = qDelta * qAngle;
                    }
                }
                fireRateTime = Time.time + 1 / fireRate;
            }
        }
    }

    public void setElite(int eliteType){
        this.eliteType = eliteType;
        isElite = true;
        if (eliteType == 0) {
            fireball = fireballHoming;
            fireForce = 1500;
        }
        else if (eliteType == 1) {
            fireball = fireballLarge;
            fireRate = 0.5f;
        }
        else if (eliteType == 2) {
            fireball = fireballSmall;
            fireRate = 2f;
            fireForce = 2500;
        }
    }
}
