using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_Menus : MonoBehaviour
{
    public GameObject PlayerHUD;
    public GameObject Menu_Pause;
    public GameObject Menu_Win;
    public GameObject Menu_Death;

    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        Menu_Pause.SetActive(false);
        Menu_Win.SetActive(false);
        Menu_Death.SetActive(false);
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            paused = true;
            Menu_Pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        paused = false;
        Menu_Pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        
    }
}
