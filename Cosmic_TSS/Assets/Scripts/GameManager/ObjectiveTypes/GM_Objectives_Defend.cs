using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Objectives_Defend : MonoBehaviour
{
    private GM_Objectives GM;

    public string zoneName;
    public float timeToDefend = 10f;
    public float timePlayerDefending;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GM_Objectives>();
        timePlayerDefending = timeToDefend;
    }

    // Update is called once per frame
    void Update()
    {
        if(timePlayerDefending <= 0)
        {
            CompleteObjective();
        }
    }

    private void OnCollisionStay(Collision c)
    {
        if(c.gameObject.tag == "Player")
        {
            timePlayerDefending -= Time.deltaTime;
        }
    }

    public void CompleteObjective()
    {
        GM.DisableCurrentObjective();
    }
}
