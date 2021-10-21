using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_HealthPickup : MonoBehaviour
{
    public float addHealth = 10f;

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;

        if(tag == "Player")
        {
            Player_Stats.health += addHealth;
            gameObject.SetActive(false);
        }
    }
}
