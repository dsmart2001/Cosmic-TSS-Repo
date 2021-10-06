using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUI_HUD : MonoBehaviour
{
    // UI Objects
    [Space]
    [Header("Player UI elements")]
    public TMP_Text playerHealth;
    public TMP_Text playerAmmo;

    [Space]
    [Header("Wave UI elements")]
    public TMP_Text waveCounter;
    public int enemiesToRevealCounter = 10;
    public TMP_Text enemyCounter;
    public TMP_Text objectiveText;

    // Start is called before the first frame update
    void Start()
    {
        enemyCounter.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = "Health > " + Player_Stats.health.ToString();
        waveCounter.text = "Wave > " + GM_WaveSystem.waveNumber.ToString();
        objectiveText.text = GM_Objectives.objectiveText;

        if(GM_WaveSystem.waveEnemyCounter <= enemiesToRevealCounter)
        {
            enemyCounter.gameObject.SetActive(true);
            enemyCounter.text = "ENEMIES REMAINING: " + GM_WaveSystem.waveEnemyCounter.ToString();
        }
    }
}
