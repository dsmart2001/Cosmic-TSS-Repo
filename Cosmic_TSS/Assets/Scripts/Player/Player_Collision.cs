using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    private Rigidbody RB => GetComponent<Rigidbody>();
    private Collider CLDR => GetComponent<Collider>();

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
            Player_Stats.health -= c.gameObject.GetComponent<Enemy_Stats>().bodyDamage;
        }

        if(tag == "EnemyBullet")
        {
            Player_Stats.health -= c.gameObject.GetComponent<Weapon_BulletVelocity>().damage;
            Destroy(c.gameObject);
        }

        if(tag =="Instadeath")
        {
            Destroy(gameObject);
        }
    }
}
