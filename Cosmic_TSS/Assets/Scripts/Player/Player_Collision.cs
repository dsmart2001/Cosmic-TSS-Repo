using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    private Rigidbody RB => GetComponent<Rigidbody>();
    private Collider CLDR => GetComponent<Collider>();
    private Player_Controls player => GetComponent<Player_Controls>();

    private float damageTimer;

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;
        
        if(tag == "Enemy")
        {
            Player_Stats.TakeDamage(c.gameObject.GetComponent<Enemy_Stats>().bodyDamage);
        }

        if(tag == "EnemyBullet")
        {
            Player_Stats.TakeDamage(c.gameObject.GetComponent<Weapon_BulletVelocity>().damage);
            Destroy(c.gameObject);
        }

        if (tag == "EnemyAcid")
        {
            damageTimer = Time.time + c.gameObject.GetComponent<Weapon_Acid>().damageTimer;
        }

        if (tag =="Instadeath")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        string tag = c.gameObject.tag;

        if(tag =="Ammo_Pistol" && player.weapons[0].ammo != player.weapons[0].ammoLimit)
        {
            player.weapons[0].ammo = player.weapons[0].ammoLimit;
            c.gameObject.SetActive(false);
        }

        if (tag == "Ammo_Shotgun" && player.weapons[1].ammo != player.weapons[1].ammoLimit)
        {
            player.weapons[1].ammo = player.weapons[1].ammoLimit;
            c.gameObject.SetActive(false);

        }

        if (tag == "Ammo_Sniper" && player.weapons[2].ammo != player.weapons[2].ammoLimit)
        {
            player.weapons[2].ammo = player.weapons[2].ammoLimit;
            c.gameObject.SetActive(false);

        }

        if (tag == "ObjectiveButton")
        {
            GM_Objectives.remainingButtons--;
            c.gameObject.SetActive(false);
        }

        if(tag == "Explosion")
        {
            Player_Stats.TakeDamage(c.gameObject.GetComponent<Explosion>().damage);
        }
    }

    private void OnTriggerStay(Collider c)
    {
        string tag = c.gameObject.tag;

        if (tag == "EnemyAcid")
        {
            if(Time.time >= damageTimer)
            {
                Player_Stats.TakeDamage(c.gameObject.GetComponent<Weapon_Acid>().damage);

                damageTimer = Time.time + c.gameObject.GetComponent<Weapon_Acid>().damageTimer;
            }
        }

        if (c.gameObject.tag == "DefendZone")
        {
            c.gameObject.GetComponent<GM_Objectives_Defend>().timePlayerDefending -= Time.deltaTime;
        }
    }
}
