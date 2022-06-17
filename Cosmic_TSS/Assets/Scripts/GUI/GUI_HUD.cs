using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUI_HUD : MonoBehaviour
{
    private GM_WaveSystem waveSystem => FindObjectOfType<GM_WaveSystem>();

    // UI Objects
    [Space]
    [Header("Player UI elements")]
    public GameObject playerHUD;
    public TMP_Text playerHealth;
    public Slider playerHealthSlider;
    public Image playerCrosshair;
    public Sprite[] crosshairs;
    public TMP_Text locationText;
    public static TMP_Text _locationText;

    [Space]
    [Header("Wave UI elements")]
    public TMP_Text waveCounter;
    public int enemiesToRevealCounter = 10;
    public TMP_Text enemyCounter;
    public Slider waveSlider;
    public GameObject waveNotification;
    public static GameObject _waveNotification;

    [Space]
    [Header("Objective UI elements")]
    public TMP_Text objectiveText;
    public Slider objectiveSlider;

    // Start is called before the first frame update
    void Awake()
    {
        enemyCounter.gameObject.SetActive(false);
        playerHealthSlider.value = Player_Stats.health;
        playerHealthSlider.maxValue = Player_Stats.health;

        _locationText = locationText;
        //GUI_HUD.UpdateLocation("Test");

        waveSlider.maxValue = waveSystem.EndWave;
        EnableObjectiveUI(false);

        _waveNotification = waveNotification;
        _waveNotification.SetActive(false);
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

        playerCrosshair.transform.position = Input.mousePosition;

        switch(Player_Controls.equippedWeapon.gunName)
        {
            case "PISTOL":
                playerCrosshair.sprite = crosshairs[0];
                break;
            case "SHOTGUN":
                playerCrosshair.sprite = crosshairs[1];

                break;
            case "SNIPER":
                playerCrosshair.sprite = crosshairs[2];

                break;
            case "MG":
                playerCrosshair.sprite = crosshairs[3];

                break;
        }

        if (GM_Objectives.objectiveWave)
        {
            objectiveText.text = GM_Objectives.objectiveText;

            switch (GM_Objectives.objectiveType)
            {
                case "DEFEND":
                    objectiveSlider.value = GM_Objectives.currentDefend.timePlayerDefending;
                    break;
                case "BUTTON":
                    objectiveSlider.value = GM_Objectives.remainingButtons;
                    break;
            }
        }

        waveSlider.value = GM_WaveSystem.waveNumber;
    }

    public static void UpdateLocation(string location)
    {
        _locationText.text = location;
    }

    public void EnableObjectiveUI(bool active)
    {
        if(active)
        {
            objectiveSlider.gameObject.SetActive(true);
            objectiveText.gameObject.SetActive(true);

            switch (GM_Objectives.objectiveType) {
                case "DEFEND":
                    objectiveSlider.maxValue = GM_Objectives.currentDefend.timeToDefend;
                    break;
                case "BUTTON":
                    objectiveSlider.maxValue = GM_Objectives.remainingButtons;
                    break;
            }
        }
        else
        {
            objectiveSlider.gameObject.SetActive(false);
            objectiveText.gameObject.SetActive(false);
        }
    }

    public static IEnumerator WaveNotification()
    {
        _waveNotification.SetActive(true);

        yield return new WaitForSeconds(5f);

        _waveNotification.SetActive(false);
    }
}
