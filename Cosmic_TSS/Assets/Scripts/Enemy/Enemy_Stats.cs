using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : MonoBehaviour
{
    public float health = 100f;
    public float bodyDamage = 10f;
    public GameObject dropObject;

    private GM_WaveSystem WaveSystem => FindObjectOfType<GM_WaveSystem>();
    private Enemy_Audio enemy_audio => GetComponent<Enemy_Audio>();

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

        if(dropObject != null)
        {
            int random = Random.Range(0, 4);

            if(random == 2)
            {
                Instantiate(dropObject, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), transform.rotation);
            }
        }

        enemy_audio.SFX_Death();

        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        enemy_audio.SFX_Growl();
    }
}
