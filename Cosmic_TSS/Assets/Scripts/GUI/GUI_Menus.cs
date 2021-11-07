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
    public GameObject Screen_Controls;

    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        Menu_Pause.SetActive(false);
        Menu_Win.SetActive(false);
        Menu_Death.SetActive(false);
        Screen_Controls.SetActive(false);
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void HideHUD(bool visible)
    {
        PlayerHUD.SetActive(visible);
    }

    public void Pause()
    {
        if(!paused && !Player_Stats.dead)
        {
            paused = true;
            Menu_Pause.SetActive(true);
            HideHUD(false);
            Time.timeScale = 0;
            Cursor.visible = true;

        }
        else
        {
            paused = false;
            Menu_Pause.SetActive(false);
            HideHUD(true);
            Time.timeScale = 1;
            Cursor.visible = false;

        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenControls(bool active)
    {
        Screen_Controls.SetActive(active);
    }
}
