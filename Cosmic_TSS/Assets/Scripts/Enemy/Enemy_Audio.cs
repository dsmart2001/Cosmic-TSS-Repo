using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Enemy_Audio : MonoBehaviour
{
    private AudioSource audioSource => GetComponent<AudioSource>();

    public AudioClip[] SFX_growls;
    public AudioClip SFX_attack;
    public AudioClip SFX_death;

    public void SFX_Growl()
    {
        int random = Random.Range(0, SFX_growls.Length - 1);

        audioSource.PlayOneShot(SFX_growls[random]);
    }

    public void SFX_Attack()
    {
        audioSource.PlayOneShot(SFX_attack);
    }

    public void SFX_Death()
    {
        audioSource.PlayOneShot(SFX_death);
    }
}
