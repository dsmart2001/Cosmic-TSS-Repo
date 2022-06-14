using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_MainMenu : MonoBehaviour
{
    // Main Menu objects
    public GameObject MainMenu;

    public GameObject creditsMenu;
    public List<GameObject> creditsPages;

    public GameObject controlsMenu;
    public List<GameObject> controlsPages;

    // Object organizing
    public List<GameObject> HideAtStart;

    // Start is called before the first frame update
    void Start()
    {
        ShowMain(true);
    }

    // Method to open and close pages of the credits menu
    public void OpenCredits(int page)
    {
        ShowMain(false);
        creditsMenu.SetActive(true);

        foreach(GameObject i in creditsPages)
        {
            i.SetActive(false);
        }

        creditsPages[page].SetActive(true);
    }

    // Method to open and close pages of the controls menu
    public void OpenControls(int page)
    {
        ShowMain(false);
        controlsMenu.SetActive(true);

        foreach (GameObject i in controlsPages)
        {
            i.SetActive(false);
        }

        controlsPages[page].SetActive(true);
    }

    // Method to show or hide the main menu
    public void ShowMain(bool active)
    {
        MainMenu.SetActive(active);

        if (active == true)
        {
            foreach (GameObject obj in HideAtStart)
            {
                obj.SetActive(false);
            }
        }
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
