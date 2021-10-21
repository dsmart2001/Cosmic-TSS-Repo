using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Objectives_ButtonRun : MonoBehaviour
{
    public bool active = false;

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            active = false;
            gameObject.SetActive(false);
        }
    }
}
