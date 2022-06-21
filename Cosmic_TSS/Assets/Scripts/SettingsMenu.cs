using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    // Audio Variables
    public Slider AudioMasterSlider;
    public Slider AudioMusicSlider;
    public Slider AudioSFXSlider;
    public AudioMixer AudioMusicMixer;
    public AudioMixer AudioSFXMixer;

    public Dropdown DisplayDropdown;
    public Dropdown GraphicsDropdown;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioMasterSlider.value = GM_Audio.masterFloat;
        AudioMusicSlider.value = 1;
        AudioSFXSlider.value = 1;
    }

    public void ChangeVolume(string volumeType)
    {
        switch(volumeType)
        {
            case "Master":
                AudioListener.volume = AudioMasterSlider.value;
                GM_Audio.masterFloat = AudioMasterSlider.value;
                break;
            case "Music":
                AudioMusicMixer.SetFloat("Master", Mathf.Log10(AudioMusicSlider.value) * 20);
                GM_Audio.musicFloat = AudioMusicSlider.value;
                break;
            case "SFX":
                AudioSFXMixer.SetFloat("Master", Mathf.Log10(AudioSFXSlider.value) * 20);
                GM_Audio.SFXFloat = AudioSFXSlider.value;
                break;
        }
    }
}
