using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_PlayerGuns : MonoBehaviour
{
    public GameObject projectile;
    public float fireRate;
    private float timer_fireRate;
    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        timer_fireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timer_fireRate)
        {
            canFire = true;
        }
    }

    // Allow firing of weapon if adhering to fire rate
    public void FireWeapon()
    {
        if(canFire)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            canFire = false;
            timer_fireRate = Time.time + fireRate;
        }
    }
}
