using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : MonoBehaviour
{
    public float health = 100f;
    public float bodyDamage = 10f;

    private GM_WaveSystem WaveSystem => FindObjectOfType<GM_WaveSystem>();

    // Update is called once per frame
    void Update()
    {
        if (health <= 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        GM_WaveSystem.remainingEnemies--;
        
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
