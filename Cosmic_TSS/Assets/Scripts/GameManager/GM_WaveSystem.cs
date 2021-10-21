using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_WaveSystem : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GM_Objectives Objectives => GetComponent<GM_Objectives>();

    [Space]
    [Header("Wave values and variables")]

    [SerializeField] public static int waveNumber = 0;
    [SerializeField] public static int waveEnemyCounter;
    [SerializeField] private GameObject[] enemiesInWave;

    public float spawnWaitTimer = 1f;
    private float spawnWaitCurrent;

    [Space]
    [Header("Spawnable Objects Prefabs")]

    public GM_WaveSystem_Enemy[] EnemyObjects;

    // Start is called before the first frame update
    void Awake()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        spawnWaitCurrent = Time.time + spawnWaitTimer;

        // Instantiate first round of enemies
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        // Trigger event once no enemies are present
        if(EnemiesDefeated())
        {
            NextWave();
            Objectives.EndOfWave();
        }
    }

    // Setup next wave and instantiate
    public void NextWave()
    {
        // Update wave numbers
        waveNumber++;
        waveEnemyCounter = 0;

        // Update total number of enemies in round
        foreach (GM_WaveSystem_Enemy enemy in EnemyObjects)
        {
            if (waveNumber >= enemy.IntroWave)
            {
                waveEnemyCounter += enemy.CurrentQuantity + enemy.AddQuanitity;
            }
        }

        // Store enemies total num
        SetEnemyVariety();

        int counter = 0;

        // Spawn from each WSE object
        foreach (GM_WaveSystem_Enemy enemy in EnemyObjects)
        {
            if(waveNumber >= enemy.IntroWave)
            {
                // Instantiate based on current number of expected enemies of each type
                for(int i = 0; i <= enemy.CurrentQuantity + enemy.AddQuanitity - 1; i++)
                {
                    int spawnNum = Random.Range(0, spawnPoints.Length);

                    enemiesInWave[counter] = Instantiate(enemy.prefab, spawnPoints[spawnNum].transform.position, spawnPoints[spawnNum].transform.rotation, spawnPoints[spawnNum].transform);
                    counter++;
                }

                // Update expected enemy types counter for next wave
                enemy.CurrentQuantity += enemy.AddQuanitity;
            }
        }
    }

    // Store current enemies in wave to array
    public void SetEnemyVariety()
    {
        enemiesInWave = new GameObject[waveEnemyCounter];
    }

    // Check if enemies still present
    private bool EnemiesDefeated()
    {
        if (enemiesInWave == null || enemiesInWave.Length == 0)
        {
            return true;
        }

        for (int i = 0; i < enemiesInWave.Length; i++)
        {
            if (enemiesInWave[i] != null)
            {
                return false;
            }
        }
        return true;
    }
}
