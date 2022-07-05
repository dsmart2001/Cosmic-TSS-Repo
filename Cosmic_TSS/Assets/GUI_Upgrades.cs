using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Upgrades : MonoBehaviour
{
    public Player_Powerups powerups;

    // Start is called before the first frame update
    void Awake()
    {
        powerups = FindObjectOfType<Player_Powerups>();
    }


}
