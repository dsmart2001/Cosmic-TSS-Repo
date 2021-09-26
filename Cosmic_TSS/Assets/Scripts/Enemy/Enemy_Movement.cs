using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private Rigidbody RB => GetComponent<Rigidbody>();
    private Collider CLDR => GetComponent<Collider>();
    private Enemy_Attack Attack => GetComponent<Enemy_Attack>();

    private Camera cameraBounds;

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cameraBounds = GameManager._playerCamera;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player_Stats.PlayerCoord);

        // Rotate enemy when within stopping distance
        if(Attack.InAttackRange(Player_Stats.PlayerCoord))
        {
            RotateTowards(Player_Stats.PlayerCoord);
        }
    }

    private void FixedUpdate()
    {
        RB.MovePosition(RB.position + ((Player_Stats.PlayerCoord.position - transform.position) * movementSpeed * Time.deltaTime));
    }

    // Override Nav Agent stopping distance stopping character rotation
    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 100f);
    }
}
