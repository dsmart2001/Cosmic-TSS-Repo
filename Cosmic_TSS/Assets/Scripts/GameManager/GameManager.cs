using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GM_Objectives))]
[RequireComponent(typeof(GM_WaveSystem))]
[RequireComponent(typeof(GM_DetectInput))]
[RequireComponent(typeof(GM_Audio))]

public class GameManager : MonoBehaviour
{
    public static GUI_Menus menus => FindObjectOfType<GUI_Menus>();
    private GM_WaveSystem waveSystem => GetComponent <GM_WaveSystem>();

    public Camera playerCamera;
    public static Camera _playerCamera;
    public static bool wonGame = false;
    public static bool paused;
    private bool debugMode = false;
    

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = true;
        Time.timeScale = 0;

        _playerCamera = playerCamera;
        paused = true;
    }

    private void Update()
    {
        // Debug controls
        if(Input.GetKey(KeyCode.Alpha0) && !debugMode)
        {
            debugMode = true;
        }

        if(debugMode)
        {
            if(Input.GetKeyDown(KeyCode.Alpha5))
            {
                GM_WaveSystem.RestartGame(true, waveSystem.depreciateWave);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                GM_WaveSystem.RestartGame(true, waveSystem.RushWave);
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                GM_WaveSystem.RestartGame(true, waveSystem.EndWave);
            }

        }


    }

    public void WinGame(bool won)
    {
        if(won)
        {
            menus.HideHUD(false);
            Cursor.visible = true;

            wonGame = true;

            Time.timeScale = 0;
            menus.Menu_Win.SetActive(true);
        }
        else
        {
            menus.HideHUD(true);
            Cursor.visible = false;

            wonGame = false;

            Time.timeScale = 1;
            menus.Menu_Win.SetActive(false);
        }
    }

    public static void DeathScreen()
    {
        Time.timeScale = 0;
        Cursor.visible = true;

        menus.Menu_Death.SetActive(true);
        menus.HideHUD(false);
    }
}

