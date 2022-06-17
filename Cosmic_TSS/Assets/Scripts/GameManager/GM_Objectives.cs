using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class GM_Objectives : MonoBehaviour
{
    public GUI_HUD GUI => FindObjectOfType<GUI_HUD>();

    public static bool objectiveWave = false;
    public static int randomObjectiveInt = 1;

    // Objective Class variables
    // Defend the Zone Objective
    public GM_Objectives_Defend[] OBJ_Defend;
    public static GM_Objectives_Defend currentDefend;
    private int defendZoneNum;

    // Button Run Objective
    public GM_Objectives_ButtonRun[] OBJ_ButtonRun;
    public static GM_Objectives_ButtonRun[] currentButtonRun;
    public static int remainingButtons;
    public static int totalButtons = 6;

    // Objective UI info
    public static string objectiveText;
    public static string objectiveType;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize objectives
        defendZoneNum = OBJ_Defend.Length;
        currentButtonRun = OBJ_ButtonRun;

        foreach(GM_Objectives_Defend i in OBJ_Defend)
        {
            Debug.Log("Added Defend Objective: " + i.gameObject.name);
            i.gameObject.SetActive(false);
        }

        foreach (GM_Objectives_ButtonRun i in OBJ_ButtonRun)
        {
            Debug.Log("Added Button Run Objective: " + i.gameObject.name);
            i.gameObject.SetActive(false);
        }

        Debug.Log("Objectives: Total number of defend zones " + defendZoneNum);

        // TESTING DEFEND \\
        //randomObjectiveInt = 1;
        //SetObjective_Defend();
        //randomObjectiveInt = 2;
        //SetObjective_ButtonRun();
        //NextObjective();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(objectiveWave)
        {
            switch (randomObjectiveInt)
            {
                // Defend 
                case 1:
                    if (currentDefend.timePlayerDefending <= 0)
                    {
                        CompleteObjective();
                    }
                    else
                    {
                        objectiveText = "Defend " + currentDefend.zoneName + ": " + currentDefend.timePlayerDefending.ToString("n2") + " sec remaining";
                    }
                    break;
                // Button Run
                case 2:
                    if (remainingButtons <= 0)
                    {
                        CompleteObjective();
                    }
                    else
                    {

                        objectiveText = "Find & Press Panic Buttons: " + remainingButtons;
                    }
                    break;
            }
        }        
    }

    // Prepare next objective and relevant conditions
    public void NextObjective() 
    {
        objectiveWave = true;

        randomObjectiveInt = Random.Range(1, 3);

        switch(randomObjectiveInt) 
        {
            // Defend 
            case 1:
                SetObjective_Defend();
                break;
            // Button Run
            case 2:
                SetObjective_ButtonRun();
                break;
        }
    }

    // Choose one of the defend zones as point for player to defend
    public void SetObjective_Defend()
    {
        int random = Random.Range(0, defendZoneNum - 1);

        Debug.Log("Objectives: Current defend zone num = " + random);

        OBJ_Defend[random].gameObject.SetActive(true);

        currentDefend = OBJ_Defend[random];

        Debug.Log("Objectives: Started new [Defend Zone] objective");

        objectiveType = "DEFEND";

        GUI.EnableObjectiveUI(true);
    }

    // Spawn a random selection of the buttons to be activated
    public void SetObjective_ButtonRun()
    {
        int random = Random.Range(OBJ_ButtonRun.Length / 2, OBJ_ButtonRun.Length - 5);

        Debug.Log("Objectives: Current button run num = " + random);

        for(int i = 0; i < random; i++)
        {
            OBJ_ButtonRun[i].active = true;
            OBJ_ButtonRun[i].gameObject.SetActive(true);
            OBJ_ButtonRun[i].GetComponent<GM_Objectives_ButtonRun>().active = true;

            remainingButtons = random;
        }
        Debug.Log("Objectives: Started new [Button Run] objective");

        objectiveType = "BUTTON";

        GUI.EnableObjectiveUI(true);
    }

    // Method to disable the current objective 
    public void DisableCurrentObjective()
    {
        switch(randomObjectiveInt)
        {
            // Defend
            case 1:
                foreach(GM_Objectives_Defend i in OBJ_Defend)
                {
                    i.gameObject.SetActive(false);
                }
                break;
            // Button run
            case 2:
                foreach (GM_Objectives_ButtonRun i in OBJ_ButtonRun)
                {
                    i.gameObject.SetActive(false);
                }
                break;
        }

        objectiveText = "";

        GUI.EnableObjectiveUI(false);
    }

    // Detect the end of a wave
    public void EndOfWave()
    {
        objectiveWave = false;
    }

    // Update conditions based on completing the current objective
    public void CompleteObjective()
    {
        Debug.Log("Objectives: Completed current objective");
        objectiveText = "OBJECTIVE COMPLETE";
        objectiveWave = false;
        DisableCurrentObjective();
    }
}
