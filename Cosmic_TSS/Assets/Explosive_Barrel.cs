using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive_Barrel : MonoBehaviour
{
    public GameObject explosion;

    private void Start()
    {
        explosion.SetActive(false);
    }
    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;

        if (tag == "Bullet")
        {
            explosion.SetActive(true);
            StartCoroutine(Explode());
        }
    }


    public IEnumerator Explode()
    {
        explosion.SetActive(true);

        yield return new WaitForSeconds(1f);

        explosion.SetActive(false);
        gameObject.SetActive(false);
    }
}
