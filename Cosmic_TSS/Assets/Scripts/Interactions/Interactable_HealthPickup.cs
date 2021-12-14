using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_HealthPickup : MonoBehaviour
{
    private AudioSource pickupAudio => GetComponent<AudioSource>();
    private MeshRenderer mesh => GetComponent<MeshRenderer>();

    public float addHealth = 10f;
    public bool active = true;

    private void OnCollisionEnter(Collision c)
    {
        string tag = c.gameObject.tag;

        if(tag == "Player" && Player_Stats.health < 250)
        {
            Player_Stats.health += addHealth;
            active = false;
            StartCoroutine(PickupHealth());

        }
    }

    public void RespawnHealth()
    {
        if (active == false)
        {
            gameObject.SetActive(true);
        }
    }

    IEnumerator PickupHealth()
    {
        pickupAudio.Play();
        mesh.enabled = false;

        yield return new WaitForSeconds(pickupAudio.clip.length);

        mesh.enabled = true;
        gameObject.SetActive(false);

    }
}
