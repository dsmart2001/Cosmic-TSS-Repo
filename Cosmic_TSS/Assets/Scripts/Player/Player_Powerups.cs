using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Powerups : MonoBehaviour
{
    public Player_Stats stats;
    public Player_Controls movement;
    public List<Weapon_PlayerGuns> weapons;

    // Start is called before the first frame update
    void Awake()
    {
        stats = FindObjectOfType<Player_Stats>();
        movement = FindObjectOfType<Player_Controls>();
        weapons = movement.weapons;
    }

    // UPGRADE: Boost total ammo capacity of weapons
    public void AmmoBoost()
    {
        foreach (Weapon_PlayerGuns weap in weapons)
        {
            weap.ammoLimit += 5;
        }
    }

    // UPGRADE: Boost total health
    public void HealthBoost()
    {
        stats.maxHealth += 10;
    }

    // UPGRADE: Boost player speed and maneuvarability
    public void MovementBoost()
    {

    }

    public void DamageBoost()
    {

    }

    // UPGRADE: Boost fire-rate of weapons
    public void FirerateBoost()
    {
        foreach (Weapon_PlayerGuns weap in weapons)
        {
            if(weap.fireRate > 0.4)
            {
                weap.fireRate -= 0.2f;
            }
        }
    }

    // UPGRADE: Boost pickup drop chance from enemies
    public void DropChanceBoost()
    {

    }

    // UPGRADE: One time use upgrade where the players first damage taken causes their body to explode
    public void ExplosiveBody()
    {

    }

    // Skip the current round
    public void SkipRound()
    {

    }

    // UPGRADE: Boost weapon accuraccy remove innacurracy debuff
    public void AccurracyBoost()
    {
        foreach(Weapon_PlayerGuns weap in weapons)
        {
            weap.accurracyReduction = 0.01f;
        }
    }

    // UPGRADE: Increase the piercing capabilities of weapons
    public void PiercingBullets()
    {

    }

    // UPGRADE: Unlock a new weapon for the arsenal
    public void NewWeapon()
    {

    }
}
