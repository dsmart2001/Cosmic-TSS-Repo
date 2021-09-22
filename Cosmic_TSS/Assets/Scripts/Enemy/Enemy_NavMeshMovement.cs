using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent agent => GetComponent<NavMeshAgent>();
    private Enemy_Attack Attack => GetComponent<Enemy_Attack>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player_Stats.PlayerCoord.position);

        // Rotate enemy when within stopping distance
        if (Attack.InAttackRange(Player_Stats.PlayerCoord))
        {
            RotateTowards(Player_Stats.PlayerCoord);
        }
    }

    // Override Nav Agent stopping distance stopping character rotation
    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }
}
