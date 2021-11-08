using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive_Barrel : MonoBehaviour
{
    public GameObject explosion;
    public float integrity = 150;

    private void Start()
    {
        explosion.SetActive(false);
    }

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;

        if (tag == "Bullet")
        {
            integrity -= c.gameObject.GetComponent<Weapon_BulletVelocity>().damage;

            if(integrity <= 0)
            {
                explosion.SetActive(true);
                StartCoroutine(Explode());
            }
        }
    }

    public IEnumerator Explode()
    {
        explosion.SetActive(true);

        yield return new WaitForSeconds(1f);

        explosion.SetActive(false);
        Destroy(gameObject);
    }
}
