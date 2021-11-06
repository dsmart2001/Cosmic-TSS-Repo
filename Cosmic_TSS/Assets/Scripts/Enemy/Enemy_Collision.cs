using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : MonoBehaviour
{
    private Enemy_Stats Stats => GetComponent<Enemy_Stats>();
    private Enemy_NavMeshMovement Movement => GetComponent<Enemy_NavMeshMovement>();

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;

        // Take damage from player attacks or kill barrier
        if(tag == "Bullet")
        {
            Stats.health -= c.gameObject.GetComponent<Weapon_BulletVelocity>().damage;
            Movement.ResetStunVelocity(c.gameObject.GetComponent<Weapon_BulletVelocity>().stunTime);
        }

        if (tag == "Instadeath")
        {
            Stats.Death();
        }

        // Take damage from fast moving object
        if(tag == "Moveable")
        {
            if(c.gameObject.GetComponent<Rigidbody>().velocity.magnitude >= 5f)
            {
                Stats.health -= 10f;
            }

            Movement.ResetStunVelocity(1f);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        string tag = c.gameObject.tag;

        if (tag == "Explosion")
        {
            Stats.TakeDamage(c.gameObject.GetComponent<Explosion>().damage);
        }
    }
}
