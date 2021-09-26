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
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;
    
    }
}
