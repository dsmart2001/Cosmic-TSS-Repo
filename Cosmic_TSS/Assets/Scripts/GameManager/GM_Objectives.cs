using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class GM_Objectives : MonoBehaviour
{
    public GM_Objectives_Defend[] OBJ_Defend => FindObjectsOfType<GM_Objectives_Defend>();
    private GM_Objectives_Defend currentDefend;
    private int defendZoneNum;

    public GM_Objectives_ButtonRun[] OBJ_ButtonRun => FindObjectsOfType<GM_Objectives_ButtonRun>();
    private GM_Objectives_ButtonRun[] currentButtonRun;
    
    public static string objectiveText;
    public static int randomObjectiveInt;

    // Start is called before the first frame update
    void Start()
    {
        defendZoneNum = OBJ_Defend.Length;

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

        Debug.Log("Objectives: Total number of defend zones" + defendZoneNum);

        // TESTING DEFEND
        randomObjectiveInt = 1;
        SetObjective_Defend();
    }

    // Update is called once per frame
    void Update()
    {
        if (EndOfWave())
        {
            NextObjective();
        }

        switch (randomObjectiveInt)
        {
            // Defend 
            case 1:
                objectiveText = "Defend " + currentDefend.zoneName + ": " + currentDefend.timePlayerDefending.ToString("n2");
                break;
            // Button Run
            case 2:
                objectiveText = "";
                break;
            // Air leak
            case 3:
                objectiveText = "";
                break;
        }
    }

    // Prepare next objective and relevant conditions
    public void NextObjective() 
    {
        randomObjectiveInt = Random.Range(1, 2);

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
            // Air leak
            case 3:
                SetObjective_AirLeak();
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
    }

    // Spawn a random selection of the buttons to be activated
    public void SetObjective_ButtonRun()
    {

    }

    // Despawn some walls that need to be repaired
    public void SetObjective_AirLeak()
    {

    }

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
            // Air leak
            case 3:

                break;
        }

        objectiveText = "";
    }

    // Detect the end of a wave
    public bool EndOfWave()
    {
        return false;
    }

    // Update conditions based on completing the current objective
    public void CompleteObjective()
    {
        objectiveText = "OBJECTIVE COMPLETE";
        DisableCurrentObjective();
    }
}
