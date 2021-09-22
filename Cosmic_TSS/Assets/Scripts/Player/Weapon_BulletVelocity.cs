using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_BulletVelocity : MonoBehaviour
{
    Rigidbody RB => GetComponent<Rigidbody>();

    public float bulletVelocity = 10f;
    public float damage = 50f;
    public float despawnDropoff = 20f;

    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {        
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = transform.forward * bulletVelocity;

        // Despawn this object when reached distance limit
        if(Vector3.Distance(spawnPos, transform.position) > despawnDropoff)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;

        // Structure hit: despawn and hit effect
        if (tag == "Structure")
        {
            Destroy(gameObject);
        }

        // Enemy hit: despawn and enemy hit effect
        if(tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
