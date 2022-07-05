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
    public GameObject Menu_Intro;
    public GameObject Menu_Settings;
    public GameObject Menu_Upgrades;

    public List<GameObject> HideAtStart;

    // Start is called before the first frame update
    void Start()
    {
        Menu_Intro.SetActive(true);

        foreach(GameObject i in HideAtStart)
        {
            i.SetActive(false);
        }

        HideHUD(false);
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
        if(!GameManager.paused && !Player_Stats.dead)
        {
            GameManager.paused = true;
            Menu_Pause.SetActive(true);
            HideHUD(false);
            Time.timeScale = 0;
            Cursor.visible = true;

        }
        else
        {
            GameManager.paused = false;
            Menu_Pause.SetActive(false);
            Menu_Intro.SetActive(false);
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
        GM_WaveSystem.RestartGame(false, 0);
    }

    public void ResetWave()
    {
        GM_WaveSystem.RestartGame(true, GM_WaveSystem.waveNumber);
    }

    public void OpenControls(bool active)
    {
        Screen_Controls.SetActive(active);
    }

    public void OpenSettings(bool active)
    {
        Menu_Settings.SetActive(active);
    }

    public void DisplayUpgrades(bool active)
    {
        Menu_Upgrades.SetActive(active);
    }

    public void CloseIntro()
    {
        GameManager.paused = false;
        Menu_Intro.SetActive(false);
        HideHUD(true);
        Time.timeScale = 1;
        Cursor.visible = false;
    }
}
