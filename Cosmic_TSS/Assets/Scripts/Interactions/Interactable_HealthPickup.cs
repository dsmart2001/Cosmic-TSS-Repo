using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_HealthPickup : MonoBehaviour
{
    public float addHealth = 10f;
    public bool active = true;

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;

        if(tag == "Player" && Player_Stats.health < 250)
        {
            Player_Stats.health += addHealth;
            active = false;
            gameObject.SetActive(false);
        }
    }

    public void RespawnHealth()
    {
        if (active == false)
        {
            gameObject.SetActive(true);
        }
    }
}
