using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUI_HUD : MonoBehaviour
{
    // UI Objects
    [Space]
    [Header("Player UI elements")]
    public TMP_Text playerHealth;
    public Slider playerHealthSlider;
    public TMP_Text playerAmmo;

    [Space]
    [Header("Wave UI elements")]
    public TMP_Text waveCounter;
    public int enemiesToRevealCounter = 10;
    public TMP_Text enemyCounter;

    [Space]
    [Header("Objective UI elements")]
    public TMP_Text objectiveText;

    // Start is called before the first frame update
    void Start()
    {
        enemyCounter.gameObject.SetActive(false);
        playerHealthSlider.value = Player_Stats.health;
        playerHealthSlider.maxValue = Player_Stats.health;
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously update relevant UI elements
        playerHealth.text = "Health > " + Player_Stats.health.ToString();
        playerHealthSlider.value = Player_Stats.health;

        if(playerHealthSlider.maxValue < Player_Stats.health)
        {
            playerHealthSlider.maxValue = Player_Stats.health;
        }

        waveCounter.text = "Wave > " + GM_WaveSystem.waveNumber.ToString();
        objectiveText.text = GM_Objectives.objectiveText;

        // Update wave UI info
        if(GM_WaveSystem.remainingEnemies <= enemiesToRevealCounter)
        {
            enemyCounter.gameObject.SetActive(true);
            enemyCounter.text = "ENEMIES REMAINING: " + GM_WaveSystem.remainingEnemies.ToString();
        }
        else
        {
            enemyCounter.gameObject.SetActive(false);
        }
    }
}
