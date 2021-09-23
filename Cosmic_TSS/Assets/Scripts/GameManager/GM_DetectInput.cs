using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GM_DetectInput : MonoBehaviour
{
    private PlayerInput PI => FindObjectOfType<Player_Controls>().GetComponent<PlayerInput>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Player_Controls.phoneControls = false;
        }

        if(PI.actions["Move"].ReadValue<Vector2>().x > 0f || PI.actions["Move"].ReadValue<Vector2>().y > 0f)
        {
            Player_Controls.phoneControls = true;
        }
    }
}
