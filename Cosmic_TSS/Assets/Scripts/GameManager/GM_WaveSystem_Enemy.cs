using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_WaveSystem_Enemy : MonoBehaviour
{
    public GameObject prefab { get; set; }
    public int Quanitity { get; set; }
    public int AddQuanitity { get; set; }
    public int IntroWave { get; set; }

    public GM_WaveSystem_Enemy(GameObject _prefab, int _Quantity, int _AddQuantity, int _IntroWave)
    {
        prefab = _prefab;
        Quanitity = _Quantity;
        AddQuanitity = _AddQuantity;
        IntroWave = _IntroWave;
    }
}
