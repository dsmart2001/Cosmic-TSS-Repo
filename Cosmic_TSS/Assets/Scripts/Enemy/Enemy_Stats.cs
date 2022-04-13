using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Stats : MonoBehaviour
{
    public float health = 100f;
    public float bodyDamage = 10f;
    public GameObject dropObject;

    private CapsuleCollider collision;
    private Enemy_NavMeshMovement movement;
    private GM_WaveSystem WaveSystem => FindObjectOfType<GM_WaveSystem>();
    private Enemy_Audio enemy_audio => GetComponent<Enemy_Audio>();

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

    public IEnumerator Death()
    {
        GM_WaveSystem.remainingEnemies--;

        movement.PauseMovement(5f);
        collision.enabled = false;

        if (dropObject != null)
        {
            int random = Random.Range(0, 4);

            if (random == 2)
            {
                Instantiate(dropObject, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), transform.rotation);
            }
        }

        enemy_audio.SFX_Death();

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
