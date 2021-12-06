using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class GM_Audio : MonoBehaviour
{
    private AudioSource source => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
