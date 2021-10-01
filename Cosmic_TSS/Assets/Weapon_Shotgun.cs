using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Shotgun : MonoBehaviour
{
    public Vector3 scaleStart;
    public Vector3 scaleEnd;
    public float scaleSpeed;
    private Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        scaleStart = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        scale = Vector3.Lerp(scaleStart, scaleEnd, scaleSpeed);

        transform.localScale = scale;
    }
}
