using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon_PlayerGuns : MonoBehaviour
{
    // Weapon characteristics
    public string gunName;
    public GameObject projectile;
    public int ammoLimit = 5;
    public int ammo;

    public float fireRate;
    private float timer_fireRate;
    private bool canFire = true;

    // Audio variables
    private AudioSource audioSource => GetComponent<AudioSource>();
    public AudioClip SFX_gunshot;
    public AudioClip SFX_empty;

    // Start is called before the first frame update
    void Start()
    {
        timer_fireRate = fireRate;
        ammo = ammoLimit;
        audioSource.clip = SFX_gunshot;
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

            audioSource.clip = SFX_gunshot;
            audioSource.Play();
        }
        else if(!canFire && ammo <= 0)
        {
            audioSource.clip = SFX_empty;
            audioSource.Play();
        }
    }
}
