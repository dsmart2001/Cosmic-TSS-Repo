using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Audio : MonoBehaviour
{
    public AudioSource movement;
    public AudioSource voice;

    public AudioClip[] damageClips;

    public void SFX_TakeDamage()
    {
        int random = Random.Range(0, damageClips.Length - 1);

        voice.clip = damageClips[random];

        voice.Play();
    }

    public void SFX_Walk()
    {
        if(!movement.isPlaying)
        {
            movement.Play();
        }
    }
}
