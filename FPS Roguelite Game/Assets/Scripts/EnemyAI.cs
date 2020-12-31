using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour{
    public GameObject player;
    public EnemyRadius enemyRadius;

    private void Start() {
        player = GameObject.Find("First Person Player");
    }

    // Update is called once per frame
    void Update() {
        if (enemyRadius.playerFound) {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
    }
}
