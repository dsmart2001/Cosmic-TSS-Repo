using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTrigger : MonoBehaviour
{
    public string locationName;

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            Debug.Log("Location Trigger " + locationName + ": Collided with player");
            GUI_HUD.UpdateLocation(locationName);
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            GUI_HUD.UpdateLocation("Hallways");
        }
    }
}
