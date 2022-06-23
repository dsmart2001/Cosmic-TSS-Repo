using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : MonoBehaviour
{
    // Enemy characteristics
    public float health = 100f;
    public float bodyDamage = 10f;
    public GameObject dropObject;

    // Get properties
    private CapsuleCollider collision;
    private Enemy_NavMeshMovement movement;
    private GM_WaveSystem WaveSystem => FindObjectOfType<GM_WaveSystem>();
    private Enemy_Audio enemy_audio => GetComponent<Enemy_Audio>();

    // Death variables
    private bool dead = false;
    public float deathRotateSpeed = 2f;
    public float deathSizeSpeed = 15f;

    public void Start()
    {
        collision = GetComponent<CapsuleCollider>();
        movement = GetComponent<Enemy_NavMeshMovement>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        //enemy_audio.SFX_Growl();

        if (health <= 0f)
        {
            StartCoroutine(Death());
        }
    }

    // Coroutine for death of this enemy
    public IEnumerator Death()
    {
        dead = true;

        // Update wave info
        GM_WaveSystem.remainingEnemies--;

        // Stop enemy actions (Play dead)
        movement.agent.speed = 0;
        collision.enabled = false;

        // Randomize chance to drop pickup item
        if (dropObject != null)
        {
            int random = Random.Range(0, 4);

            if (random == 2)
            {
                Instantiate(dropObject, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), transform.rotation);
            }
        }

        enemy_audio.SFX_Death();

        yield return new WaitForSeconds(enemy_audio.SFX_death.length);

        Destroy(gameObject);
    }

    private void Update()
    {
        if(dead)
        {
            transform.Rotate(Vector3.up * (deathRotateSpeed * Time.deltaTime));
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.1f, 0.1f, 0.1f), deathSizeSpeed * Time.deltaTime);
        }
    }
}
