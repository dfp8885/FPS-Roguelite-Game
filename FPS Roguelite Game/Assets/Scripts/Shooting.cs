using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public FloorProgressBar floorProgressBar;
    public GameObject bullet;
    public GameObject hitMarker;
    public GameObject critHitMarker;
    public Transform firePoint;
    public float fireRate = 10f;
    public float fireForce = 10f;

    private float hitMarkerTime;
    private float fireRateTime = 0f;
    private int numOfKills = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")) {
            if (Time.time > fireRateTime) {
                GameObject go = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
                go.GetComponent<Bullet>().setGun(this);
                go.GetComponent<Rigidbody>().AddForce(firePoint.forward * fireForce);
                fireRateTime = Time.time + 1/fireRate;
            }
        }
        if (hitMarkerTime > 0)
        {
            hitMarkerTime -= Time.deltaTime;
        }
        else if (hitMarker.activeSelf) {
            hitMarker.SetActive(false);
        }
        else if (critHitMarker.activeSelf) {
            critHitMarker.SetActive(false);
        }
    }

    public void incrementKills(int amount) {
        numOfKills++;

        // Award player with floor progress
        floorProgressBar.addFloorProgress(amount);

        // Award player with XP
    }

    public void resetKills(){
        numOfKills = 0;
    }

    public int getNumOfKills() {
        return numOfKills;
    }

    public void objectHit(bool crit) {
        if (crit) {
            critHitMarker.SetActive(true);
        }
        else {
            hitMarker.SetActive(true);
        }
        hitMarkerTime = 0.2f;
    }
}
