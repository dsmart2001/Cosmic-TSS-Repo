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

    public float distanceToSpeedUp = 30f;
    [SerializeField] private float speedUpSpeed;

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

        //speedUpSpeed = agent.speed * 1.5f;
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

        // Modify speed based on conditions
        // If far away from player or offscreen
        if (Vector3.Distance(transform.position, Player_Stats.PlayerCoord.position) > distanceToSpeedUp)
        {
            agent.speed = speedUpSpeed;
        }
        // If attacking
        else if (paused && Time.time! >= pauseTimer)
        {
            agent.speed = 1f;
        }
        // Reset to standard speed
        else
        {
            agent.speed = setSpeed;
        }

        // Reset velocity after stun
        if (stunned && Time.time >= stunTimer)
        {
            rigidBody.velocity = Vector3.zero;
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
