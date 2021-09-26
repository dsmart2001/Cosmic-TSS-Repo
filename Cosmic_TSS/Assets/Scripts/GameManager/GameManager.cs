using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera playerCamera;
    public static Camera _playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;

        _playerCamera = playerCamera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
