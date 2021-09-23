using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_WaveSystem : MonoBehaviour
{
    public Transform[] spawnPoints;
    public  GameObject enemyMeleePrefab;
    public  GameObject enemyPistolPrefab;
    public  GameObject enemySniperPrefab;
    public  GameObject enemyHeavyPrefab;
    public  GameObject enemyShotgunPrefab;

    //public GM_WaveSystem_Enemy enemyWaves_Melee = new GM_WaveSystem_Enemy(enemyMeleePrefab, 5, 3, 0);

    [Space]

    private GameObject[] currentEnemies;

    [SerializeField] private int waveNumber = 0;
    public int waveEnemyNumber;
    private int _waveEnemyAdd;

    [Space]

    public int waveStartPistol;
    public int wavePistolAdd;

    public int waveStartSniper;
    public int waveSniperAdd;

    public int waveStartShotgun;
    public int waveShotgunAdd;

    public int waveStartHeavy;
    public int waveHeavyAdd;


    // Start is called before the first frame update
    void Start()
    {
        SetEnemyVariety();
        NextWave();
        _waveEnemyAdd = waveEnemyNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemiesDefeated())
        {
            NextWave();
        }
    }

    public void NextWave()
    {
        waveNumber++;
        waveEnemyNumber += _waveEnemyAdd;

        for (int i = 0; i <= waveEnemyNumber - 1; i++)
        {
            int spawn = Random.Range(0, spawnPoints.Length);

            currentEnemies[i] = Instantiate(enemyMeleePrefab, spawnPoints[spawn].position, spawnPoints[spawn].rotation, spawnPoints[spawn]);
        }

        SetEnemyVariety();
    }

    public void SetEnemyVariety()
    {
        currentEnemies = new GameObject[waveEnemyNumber];
    }

    private bool EnemiesDefeated()
    {
        if (currentEnemies == null || currentEnemies.Length == 0)
        {
            return true;
        }

        for (int i = 0; i < currentEnemies.Length; i++)
        {
            if (currentEnemies[i] != null)
            {
                return false;
            }
        }

        return true;
    }
}
