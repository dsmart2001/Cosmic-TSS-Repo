using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Ammo : MonoBehaviour
{
    public bool active = true;

    public void RespawnAmmo()
    {
        if(active == false)
        {
            gameObject.SetActive(true);
        }
    }
}
