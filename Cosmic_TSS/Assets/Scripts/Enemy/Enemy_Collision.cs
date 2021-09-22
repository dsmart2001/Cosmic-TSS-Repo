using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Collision : MonoBehaviour
{
    private Enemy_Stats Stats => GetComponent<Enemy_Stats>();

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;

        // Take damage from player attacks
        if(tag == "Bullet")
        {
            Stats.health -= c.gameObject.GetComponent<Weapon_BulletVelocity>().damage;
        }

        if (tag == "Instadeath")
        {
            Destroy(gameObject);
        }
    }
}
