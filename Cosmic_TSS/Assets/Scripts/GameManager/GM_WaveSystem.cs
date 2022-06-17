using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameManager))]
[RequireComponent(typeof(GM_Objectives))]
[RequireComponent(typeof(GM_Audio))]

public class GM_WaveSystem : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GM_Objectives Objectives => GetComponent<GM_Objectives>();
    public GameManager GM => GetComponent<GameManager>();
    private GM_Audio gm_audio => GetComponent<GM_Audio>();

    [SerializeField] private Interactable_Ammo[] ammoPickups;
    [SerializeField] private Interactable_HealthPickup[] healthPickups;

    [Space]
    [Header("Wave condition variables")]
    public int EndWave = 2;
    public int RushWave = 6;
    private int RushWaveCounter;
    public int ObjectiveWave = 3;
    private int ObjectiveWaveCounter;

    [Space]
    [Header("Wave values and variables")]

    public static bool newWaveStarting = false;
    private bool spawningEnemies = true;

    [SerializeField] public static int waveNumber = 0;
    [SerializeField] public static int waveEnemyCounter;
    [SerializeField] private List<GameObject> enemiesInWave = new List<GameObject>();

    public static int remainingEnemies;

    public float spawnWaitTimer = 1f;
    public float spawnObjectiveWaitTimer = 5f;
    public int spawnObjectiveMax = 20;

    [Space]
    [Header("Spawnable Objects Prefabs")]

    public GM_WaveSystem_Enemy[] EnemyObjects;
    public static GM_WaveSystem_Enemy[] _EnemyObjects;

    private static bool debugWave = false;
    private static int newDebugWave;

    [Space]
    [Header("Spawnable Objects Prefabs")]

    public AudioClip SFX_newWave;
    public AudioClip SFX_objectiveWave;
    public AudioClip SFX_rushWave;
    public AudioClip SFX_finalWave;

    // Start is called before the first frame update
    void Awake()
    {
        ammoPickups =  FindObjectsOfType<Interactable_Ammo>();
        healthPickups = FindObjectsOfType<Interactable_HealthPickup>();
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        Debug.Log("Wave System > Ammo Pickups found: " + ammoPickups.Length);
        Debug.Log("Wave System > Health Pickups found: " + healthPickups.Length);
        Debug.Log("Wave System > Spawnpoints found: " + spawnPoints.Length);

        RushWaveCounter = RushWave;
        ObjectiveWaveCounter = ObjectiveWave;

        _EnemyObjects = EnemyObjects;

        if (debugWave)
        {
            foreach (GM_WaveSystem_Enemy enemy in _EnemyObjects)
            {
                enemy.CurrentQuantity = (enemy.CurrentQuantity += (enemy.AddQuanitity * (waveNumber - enemy.IntroWave)));
            }
        }
    }

    private void Start()
    {
        // Instantiate first round of enemies
        NextWave();
    }

    // Update is called once per frame
    void Update()
    {
        // Trigger event once no enemies are present
        if (remainingEnemies == 0)
        {
            ClearEmptyEnemies();
        }

        if(EnemiesDefeated() && !GameManager.wonGame)
        {
            if (GM_Objectives.objectiveWave == true)
            {
                Objectives.EndOfWave();
            }

            if(waveNumber != EndWave)
            {
                NextWave();
            }
            else
            {
                GM.WinGame(true);
            }
        }
    }

    // Setup next wave and instantiate
    public void NextWave()
    {
        spawningEnemies = true;

        // Update wave numbers
        waveNumber++;
        waveEnemyCounter = 0;

        // Initiate next objective
        if (waveNumber == ObjectiveWaveCounter && waveNumber != EndWave)
        {
            Objectives.NextObjective();
            ObjectiveWaveCounter += ObjectiveWave;
        }
        else if((waveNumber == ObjectiveWaveCounter && waveNumber == EndWave))
        {
            ObjectiveWaveCounter += ObjectiveWave;
        }

        // Update total number of enemies in round
        waveEnemyCounter = 0;

        foreach (GM_WaveSystem_Enemy enemy in EnemyObjects)
        {
            if (waveNumber >= enemy.IntroWave)
            {
                waveEnemyCounter += enemy.CurrentQuantity + (enemy.AddQuanitity * waveNumber);
                
            }
        }

        int counter = 0;

        // Spawn from each WSE object
        foreach (GM_WaveSystem_Enemy enemy in EnemyObjects)
        {
            if(waveNumber >= enemy.IntroWave)
            { 
                StartCoroutine(SpawnNextEnemy(counter, enemy));
            }
        }

        // Respawn Interactables
        foreach(Interactable_Ammo i in ammoPickups)
        {
            i.RespawnAmmo();
        }

        foreach (Interactable_HealthPickup i in healthPickups)
        {
            i.RespawnHealth();
        }

        spawningEnemies = false;
        Debug.Log("Starting new wave > Enemy counter = " + remainingEnemies + " > Objective wave? = " + GM_Objectives.objectiveWave + " > Rush wave? ");

        StartCoroutine(GUI_HUD.WaveNotification());

        // Wave SFX
        if (waveNumber == EndWave)
        {
            gm_audio.PlaySound(SFX_finalWave);
        }
        else if (waveNumber == ObjectiveWaveCounter)
        {
            gm_audio.PlaySound(SFX_objectiveWave);
        }
        else if(waveNumber == RushWave)
        {
            gm_audio.PlaySound(SFX_rushWave);
        }
        else
        {
            gm_audio.PlaySound(SFX_newWave);
        }
    }

    // Check if enemies still present
    private bool EnemiesDefeated()
    {
        // Check number of enemies
        if (spawningEnemies)
        {
            return false;
        }

        foreach(GameObject i in enemiesInWave)
        {
            if(i != null)
            {
                return false;
            }
        }
        
        return true;       
    }

    // Coroutine to spawn enemies given the WaveSystem Enemy class
    IEnumerator SpawnNextEnemy(int allEnemyCounter, GM_WaveSystem_Enemy enemyPrefab)
    {
        int currentEnemyCounter = 0;

        switch (GM_Objectives.objectiveWave) 
        {
            case false:
                while (currentEnemyCounter <= enemyPrefab.CurrentQuantity + enemyPrefab.AddQuanitity - 1)
                {
                    Debug.Log("Wave System: Spawned new " + enemyPrefab.name);

                    // Spawn new enemy at random spawn points
                    int spawnNum = Random.Range(0, spawnPoints.Length);

                    enemiesInWave.Add(Instantiate(enemyPrefab.prefab, spawnPoints[spawnNum].transform.position, spawnPoints[spawnNum].transform.rotation, spawnPoints[spawnNum].transform));
                    allEnemyCounter++;
                    currentEnemyCounter++;
                    remainingEnemies++;

                    yield return new WaitForSeconds(spawnWaitTimer);
                }
                break;
            case true:
                while (GM_Objectives.objectiveWave && remainingEnemies <= spawnObjectiveMax)
                {
                    Debug.Log("Wave System: Spawned new " + enemyPrefab.name + " in objective wave");

                    // Spawn new enemy at random spawn points
                    int spawnNum = Random.Range(0, spawnPoints.Length);

                    enemiesInWave.Add(Instantiate(enemyPrefab.prefab, spawnPoints[spawnNum].transform.position, spawnPoints[spawnNum].transform.rotation, spawnPoints[spawnNum].transform));

                    allEnemyCounter++;
                    remainingEnemies++;

                    yield return new WaitForSeconds(spawnObjectiveWaitTimer);
                }
                break;
        }
        // Update expected enemy types counter for next wave
        enemyPrefab.CurrentQuantity += enemyPrefab.AddQuanitity;
    }

    // Method to remove empty slots in enemy list
    public void ClearEmptyEnemies()
    {
        // Remove null enemies in list
        enemiesInWave.RemoveAll(item => item == null);
    }

    // Method to restart game
    public static void RestartGame(bool resetWave, int newWaveNumber)
    {
        if(!resetWave)
        {
            waveNumber = 0;
        }
        else
        {
            debugWave = true;
            waveNumber = newWaveNumber - 1;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
    }
}
