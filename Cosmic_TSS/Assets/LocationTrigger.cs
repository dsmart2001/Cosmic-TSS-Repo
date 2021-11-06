using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTrigger : MonoBehaviour
{
    public string locationName;

    private void OnTriggerStay(Collision c)
    {
        if(c.gameObject.tag == "Player")
        {
            GUI_HUD.UpdateLocation(locationName);
        }
    }

    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            GUI_HUD.UpdateLocation("");
        }
    }
}
