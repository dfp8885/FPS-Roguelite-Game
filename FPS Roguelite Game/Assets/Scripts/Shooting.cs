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
        // If Fire1 is pressed fire bullet
        // This implementation allows for the player to hold down the fire button
        if (Input.GetButton("Fire1")) {
            // An if statement is used here to only allow the gun to shoot at certain intervals
            // this is to mimic a gun's rate of fire
            if (Time.time > fireRateTime) {
                GameObject go = (GameObject)Instantiate(bullet, firePoint.position, firePoint.rotation);
                go.GetComponent<Bullet>().setGun(this);
                go.GetComponent<Rigidbody>().AddForce(firePoint.forward * fireForce);
                fireRateTime = Time.time + 1/fireRate;
            }
        }

        // Reset hitmarker after a hitMarkerTime
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

    // setter to reset num of player kills
    public void resetKills(){
        numOfKills = 0;
    }

    // getter to get num of player kills
    public int getNumOfKills() {
        return numOfKills;
    }

    // function is used to not
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
