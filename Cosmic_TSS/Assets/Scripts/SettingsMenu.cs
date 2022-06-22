using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public static bool fullscreen;

    // Audio Variables
    public Slider AudioMasterSlider;
    public Slider AudioMusicSlider;
    public Slider AudioSFXSlider;
    public AudioMixer AudioMusicMixer;
    public AudioMixer AudioSFXMixer;

    public Dropdown DisplayDropdown;
    public Dropdown GraphicsDropdown;

    public Toggle FullscreenToggle;

    // Start is called before the first frame update
    void Start()
    {
        AudioMasterSlider.value = GM_Audio.masterFloat;
        AudioMusicSlider.value = 1;
        AudioSFXSlider.value = 1;

        fullscreen = Screen.fullScreen;
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

    public void Fullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        fullscreen = Screen.fullScreen;
    }

    public void DisplaySize() 
    {

        switch(DisplayDropdown.value)
        {
            case 0:
                Screen.SetResolution(480, 320, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(960, 640, Screen.fullScreen);

                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreen);

                break;
            case 3:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);

                break;
            case 4:
                Screen.SetResolution(2560, 1440, Screen.fullScreen);

                break;
        }
    }

    public void GraphicsSetting()
    {
        switch(GraphicsDropdown.value)
        {

        }
    }
}
