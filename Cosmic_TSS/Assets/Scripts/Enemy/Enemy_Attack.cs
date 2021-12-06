using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy_NavMeshMovement))]

public class Enemy_Attack : MonoBehaviour
{
    private Enemy_NavMeshMovement movement => GetComponent<Enemy_NavMeshMovement>();
    private Enemy_Audio enemy_audio => GetComponent<Enemy_Audio>();

    // Attack stat variables
    public GameObject attackObject;
    public float attackRange;
    public float attackInterval;
    public float pauseForAttack;

    private float attackTimer;
    private float attackTimerAdd;

    // Start is called before the first frame update
    void Start()
    {
        attackTimerAdd = attackInterval;

        attackTimer = Time.time + attackTimerAdd;
    }

    // Update is called once per frame
    void Update()
    {
        // Attack: Check if within attackRange and surpassed attackTimer to attack player
        if(InAttackRange(Player_Stats.PlayerCoord) && Time.time > attackTimer)
        {
            
            Attack();
            attackTimer = Time.time + attackTimerAdd;
        }
    }

    // Commit the attack event from this objects location
    public void Attack()
    {
        movement.PauseMovement(pauseForAttack);
        Instantiate(attackObject, transform.position, transform.rotation);

        enemy_audio.SFX_Attack();
    }

    // Detect if player is within attack rande
    public bool InAttackRange(Transform target)
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return distance < attackRange;
    }
}
