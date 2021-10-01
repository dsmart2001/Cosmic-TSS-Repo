using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavMeshMovement : MonoBehaviour
{
    // Get Components
    private NavMeshAgent agent => GetComponent<NavMeshAgent>();
    private Enemy_Attack Attack => GetComponent<Enemy_Attack>();
    private Rigidbody rigidBody => GetComponent<Rigidbody>();

    // Camera bounds
    private Camera cameraBounds;
    private float setSpeed;

    // Stun variables
    private bool paused = false;
    private float pauseTimer;
    private bool stunned = false;
    public float stunTimer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        cameraBounds = GameManager._playerCamera;
        setSpeed = agent.speed;
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

        // Detect if enemy is off camera
        Vector3 viewPos = cameraBounds.WorldToViewportPoint(transform.position);

        if (viewPos.x > 1f || viewPos.x < 0f || viewPos.y > 1f || viewPos.y <0f)
        {
            agent.speed = 10f;
        }
        else
        {
            agent.speed = setSpeed;
        }

        // Reset velocity after stun
        if(stunned && Time.time >= stunTimer)
        {
            rigidBody.velocity = Vector3.zero;
        }

        // Pause movement before attacking
        if(paused && Time.time !>= pauseTimer)
        {
            agent.speed = 1f;
        }
        else
        {
            agent.speed = setSpeed;
        }
    }

    // Override Nav Agent stopping distance stopping character rotation
    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    // Call from collision script to reset velocity after colliding with a player attack. Fixes continuous velocity the attack causes.
    public void ResetStunVelocity(float timeToReset)
    {
        stunned = true;
        stunTimer = Time.time + timeToReset;
    }

    // Call from attack script to pause movement before attacking
    public void PauseMovement(float pauseTime)
    {
        pauseTimer = Time.time + pauseTime;
    }
}
