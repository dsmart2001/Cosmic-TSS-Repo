using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_PlayerGuns : MonoBehaviour
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void FireWeapon()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
