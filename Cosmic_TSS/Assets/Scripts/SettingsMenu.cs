using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public static bool fullscreen;

    // Audio Variables
    public Slider audioMasterSlider;
    public Slider audioMusicSlider;
    public Slider audioSFXSlider;
    public AudioMixer audioMusicMixer;
    public AudioMixer audioSFXMixer;

    // Display and Graphics Variables
    public TMP_Dropdown displayDropdown;
    public static int displayValue = 3;

    public TMP_Dropdown graphicsDropdown;
    public static int graphicsValue = 2;

    public Toggle fullscreenToggle;

    // Start is called before the first frame update
    void Start()
    {
        fullscreen = Screen.fullScreen;

        displayDropdown.value = displayValue;
        graphicsDropdown.value = graphicsValue;

        audioMasterSlider.value = GM_Audio.masterFloat;
        audioMusicSlider.value = 1;
        audioSFXSlider.value = 1;
    }

    public void ChangeVolume(string volumeType)
    {
        switch(volumeType)
        {
            case "Master":
                AudioListener.volume = audioMasterSlider.value;
                GM_Audio.masterFloat = audioMasterSlider.value;
                break;
            case "Music":
                audioMusicMixer.SetFloat("Master", Mathf.Log10(audioMusicSlider.value) * 20);
                GM_Audio.musicFloat = audioMusicSlider.value;
                break;
            case "SFX":
                audioSFXMixer.SetFloat("Master", Mathf.Log10(audioSFXSlider.value) * 20);
                GM_Audio.SFXFloat = audioSFXSlider.value;
                break;
        }
    }

    public void Fullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        fullscreen = Screen.fullScreen;
    }

    public void DisplaySize(int value) 
    {
        switch(value)
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

        displayValue = value;
    }

    public void GraphicsSetting(int value)
    {
        QualitySettings.SetQualityLevel(value);
        Debug.Log("SETTINGS: Set QUality level to index " + value);

        graphicsValue = value;
    }
}
