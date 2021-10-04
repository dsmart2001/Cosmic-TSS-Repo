using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    public static Transform PlayerCoord;
    public float _health = 100f;
    public static float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        health = _health;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCoord = gameObject.transform;

        if(health <= 0f)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public static void TakeDamage(float damage)
    {
        health -= damage;
    }
}
