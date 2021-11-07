using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_MainMenu : MonoBehaviour
{
    public GameObject creditsMenu;
    public GameObject controlsMenu;

    // Start is called before the first frame update
    void Start()
    {
        creditsMenu.SetActive(false);
        controlsMenu.SetActive(false);

    }

    public void OpenCredits(bool active)
    {
        creditsMenu.SetActive(active);
    }

    public void OpenControls(bool active)
    {
        controlsMenu.SetActive(active);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
