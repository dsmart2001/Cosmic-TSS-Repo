using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Acid : MonoBehaviour
{
    public float damage = 5f;
    public float damageTimer = 1f;
    public float despawnTimer = 5f;

    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        spawnPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, despawnTimer);
    }

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;
        
    }
}
