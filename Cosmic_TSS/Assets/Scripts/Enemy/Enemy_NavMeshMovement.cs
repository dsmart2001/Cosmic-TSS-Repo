using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent agent => GetComponent<NavMeshAgent>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player_Stats.PlayerCoord.position);
    }
}
