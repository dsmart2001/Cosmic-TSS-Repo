using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_MainMenu : MonoBehaviour
{
    // Main Menu objects
    public GameObject creditsMenu;
    public GameObject controlsMenu;

    // Object organizing
    public List<GameObject> HideAtStart;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obj in HideAtStart) 
        {
            obj.SetActive(false);
        }
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
