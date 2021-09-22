using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public GameObject attackObject;
    public float attackRange;
    public float attackInterval;

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

    public void Attack()
    {
        Instantiate(attackObject, transform.position, transform.rotation);
    }

    public bool InAttackRange(Transform target)
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return distance < attackRange;
    }
}
