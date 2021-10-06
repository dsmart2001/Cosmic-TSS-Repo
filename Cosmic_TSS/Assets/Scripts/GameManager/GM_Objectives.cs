using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Objectives : MonoBehaviour
{
    public GM_Objectives_Defend[] OBJ_Defend;
    public GM_Objectives_ButtonRun[] OBJ_ButtonRun;
    public static string objectiveText;
    private int randomObjectiveInt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EndOfWave())
        {
            NextObjective();
        }
    }

    // Prepare next objective and relevant conditions
    public void NextObjective() 
    {
        randomObjectiveInt = Random.Range(1, 2);

        switch(randomObjectiveInt) 
        {
            case 1:
                SetObjective_Defend();
                break;
            case 2:
                SetObjective_ButtonRun();
                break;
            case 3:

                break;
        }
    }

    // Choose one of the defend zones as point for player to defend
    public void SetObjective_Defend()
    {

    }

    // Spawn a random selection of the buttons to be activated
    public void SetObjective_ButtonRun()
    {

    }

    // Despawn some walls that need to be repaired
    public void SetObjective_AirLeak()
    {

    }

    // Detect the end of a wave
    public bool EndOfWave()
    {
        return false;
    }
}
