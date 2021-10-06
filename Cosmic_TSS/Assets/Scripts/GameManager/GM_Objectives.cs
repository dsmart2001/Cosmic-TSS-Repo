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

    public void SetObjective_Defend()
    {

    }

    public void SetObjective_ButtonRun()
    {

    }

    public void SetObjective_AirLeak()
    {

    }

    public bool EndOfWave()
    {
        return false;
    }
}
