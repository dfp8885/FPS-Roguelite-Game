using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform gun;
    public float fireRate = 10f;
    public float fireForce = 10f;
    
    private float fireRateTime = 0f;
    private int numOfKills = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")) {
            if (Time.time > fireRateTime) {
                GameObject go = (GameObject)Instantiate(bullet, gun.position, gun.rotation);
                go.GetComponent<Bullet>().setGun(this);
                go.GetComponent<Rigidbody>().AddForce(gun.forward * fireForce);
                fireRateTime = Time.time + 1/fireRate;
            }
        }
    }

    public void incrementKills() {
        numOfKills++;
    }

    public void resetKills(){
        numOfKills = 0;
    }

    public int getNumOfKills() {
        return numOfKills;
    }
}
