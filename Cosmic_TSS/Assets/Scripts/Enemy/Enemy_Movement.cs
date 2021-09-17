using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private Rigidbody RB => GetComponent<Rigidbody>();
    private Collider CLDR => GetComponent<Collider>();

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player_Stats.PlayerCoord);

        Vector3 movementDirection = Player_Stats.PlayerCoord.position - transform.position;

    }

    private void FixedUpdate()
    {
        RB.MovePosition(RB.position + ((Player_Stats.PlayerCoord.position - transform.position) * movementSpeed * Time.deltaTime));
    }
}
