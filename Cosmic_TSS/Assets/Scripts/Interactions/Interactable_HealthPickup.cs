using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_HealthPickup : MonoBehaviour
{
    public float addHealth = 10f;

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

        if(tag == "Player")
        {
            Player_Stats.health += addHealth;
            Destroy(gameObject);
        }
    }
}
