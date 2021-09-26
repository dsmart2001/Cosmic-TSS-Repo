using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    private Rigidbody RB => GetComponent<Rigidbody>();
    private Collider CLDR => GetComponent<Collider>();

    private float damageTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }
}
