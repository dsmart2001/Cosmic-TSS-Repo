using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : MonoBehaviour
{
    private Enemy_Stats Stats => GetComponent<Enemy_Stats>();
    private Enemy_NavMeshMovement Movement => GetComponent<Enemy_NavMeshMovement>();

    // Start is called before the first frame update
    void Start()
    {

    }

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
}
