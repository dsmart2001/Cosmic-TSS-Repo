using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_BulletVelocity : MonoBehaviour
{
    Rigidbody RB => GetComponent<Rigidbody>();

    float bulletVelocity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(3, 6, true);
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = transform.forward * bulletVelocity;
    }

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;

        if(tag == "Structure")
        {
            Destroy(gameObject);
        }

        if(tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
