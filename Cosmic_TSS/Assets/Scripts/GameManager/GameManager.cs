using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GUI_Menus menus => FindObjectOfType<GUI_Menus>();

    public Camera playerCamera;
    public static Camera _playerCamera;
    public static bool wonGame = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Time.timeScale = 1;

        _playerCamera = playerCamera;
    }


    public static void WinGame()
    {
        menus.HideHUD(false);
        Cursor.visible = true;

        wonGame = true;

        Time.timeScale = 0;
        menus.Menu_Win.SetActive(true);
    }

    public static void DeathScreen()
    {
        Time.timeScale = 0;
        Cursor.visible = true;

        menus.Menu_Death.SetActive(true);
        menus.HideHUD(false);
    }
}

