using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class GM_Audio : MonoBehaviour
{
    public static float masterFloat = 1;
    public static float SFXFloat = 1;
    public static float musicFloat = 1;

    private AudioSource source => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
