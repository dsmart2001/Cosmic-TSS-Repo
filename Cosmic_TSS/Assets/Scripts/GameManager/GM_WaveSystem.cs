using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_WaveSystem : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyMelee;
    public GameObject enemySniper;
    public GameObject enemyHeavy;
    public GameObject enemyShotgun;

    private GameObject[] currentEnemies;

    [SerializeField] private int waveNumber = 0;
    public int waveEnemyNumber;
    private int _waveEnemyAdd;

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

            currentEnemies[i] = Instantiate(enemyMelee, spawnPoints[spawn].position, spawnPoints[spawn].rotation, spawnPoints[spawn]);
        }
    }

    public void SetEnemyVariety()
    {
        currentEnemies = null;
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
