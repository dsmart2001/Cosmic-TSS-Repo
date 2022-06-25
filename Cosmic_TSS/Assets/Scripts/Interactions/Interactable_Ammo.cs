using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Ammo : MonoBehaviour
{
    private AudioSource pickupAudio => GetComponent<AudioSource>();
    private MeshRenderer mesh => GetComponent<MeshRenderer>();

    public bool active = true;

    public void RespawnAmmo()
    {
        if (active == false)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider c)
    {
        string tag = c.gameObject.tag;

        if (tag == "Player")
        {
            //active = false;
            //StartCoroutine(PickupAmmo());
        }
    }

    public IEnumerator PickupAmmo()
    {
        pickupAudio.Play();
        mesh.enabled = false;

        yield return new WaitForSeconds(pickupAudio.clip.length);

        mesh.enabled = true;
        gameObject.SetActive(false);

    }
}
