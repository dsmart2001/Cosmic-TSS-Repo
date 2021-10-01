using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUI_HUD : MonoBehaviour
{
    // UI Objects
    public TMP_Text health;
    public TMP_Text waveCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health > " + Player_Stats.health.ToString();
        waveCounter.text = "Wave > " + GM_WaveSystem.waveNumber.ToString();
    }
}
