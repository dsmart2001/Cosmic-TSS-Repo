using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    /*
     * 
     */

    // Player objects and components
    private Rigidbody RB => GetComponent<Rigidbody>();

    // Player stats
    private Vector3 movementVector;
    public float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            movementVector /= 1.5f;
        }
    }

    private void FixedUpdate()
    {

        RB.MovePosition(RB.position + (movementVector * movementSpeed * Time.deltaTime));
    }
}
