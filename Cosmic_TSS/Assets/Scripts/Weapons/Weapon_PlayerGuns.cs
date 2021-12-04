using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon_PlayerGuns : MonoBehaviour
{
    public string gunName;
    public GameObject projectile;
    public int ammoLimit = 5;
    public int ammo;

    public float fireRate;
    private float timer_fireRate;
    private bool canFire = true;

    private AudioSource audio => GetComponent<AudioSource>();

    // Start is called before the first frame update
    void Start()
    {
        timer_fireRate = fireRate;
        ammo = ammoLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timer_fireRate && ammo > 0)
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
            ammo--;

            audio.Play();
        }
    }
}
