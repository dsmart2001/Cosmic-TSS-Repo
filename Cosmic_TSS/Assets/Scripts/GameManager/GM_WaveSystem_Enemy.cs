using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_WaveSystem_Enemy : MonoBehaviour
{
    public GameObject prefab;
    public int CurrentQuantity;
    public int AddQuanitity;
    public int IntroWave;

    public GM_WaveSystem_Enemy(GameObject _prefab, int _CurrentQuantity, int _AddQuantity, int _IntroWave)
    {
        prefab = _prefab;
        CurrentQuantity = _CurrentQuantity;
        AddQuanitity = _AddQuantity;
        IntroWave = _IntroWave;
    }
}
