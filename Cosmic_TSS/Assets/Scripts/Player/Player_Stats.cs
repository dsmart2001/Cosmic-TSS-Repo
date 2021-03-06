using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    // Player state variables
    public static Transform PlayerCoord;
    public float _health = 100f;
    public static float health = 100f;
    public float maxHealth = 250;
    public static bool dead = false;

    public Player_Audio player_audio => GetComponent<Player_Audio>();

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
        GameManager.DeathScreen();
        dead = true;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        player_audio.SFX_TakeDamage();
    }
}
