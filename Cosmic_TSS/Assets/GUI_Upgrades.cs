using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Upgrades : MonoBehaviour
{
    public Player_Powerups powerups;

    public List<Button> upgradeOptions;

    // Start is called before the first frame update
    void Start()
    {
        powerups = FindObjectOfType<Player_Powerups>();
    }

    public void RandomizePowerups()
    {

    }
}
