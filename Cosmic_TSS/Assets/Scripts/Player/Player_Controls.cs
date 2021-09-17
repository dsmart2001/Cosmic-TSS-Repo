using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controls : MonoBehaviour
{
    /*
     * 
     */

    // Player objects and components
    private Rigidbody RB => GetComponent<Rigidbody>();
    private Collider CLDR => GetComponent<Collider>();
    private PlayerInput PI => GetComponent<PlayerInput>();

    public GameObject Bullet;

    public static bool phoneControls = true;

    // Player movement values
    private Vector2 AimInput;
    private Vector3 movementVector;
    public float movementSpeed;
    public float aimSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get Movement inputs
        if(!phoneControls)
        {
            movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        }
        else
        {
            movementVector = new Vector3(PI.actions["Move"].ReadValue<Vector2>().x, 0f, PI.actions["Move"].ReadValue<Vector2>().y);
        }

        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            movementVector /= 1.5f;
        }

        // Aim inputs
        AimInput = PI.actions["Aim"].ReadValue<Vector2>();

        float angle = AngleBetweenTwoPoints(Vector2.zero, AimInput);

        transform.rotation = Quaternion.Euler(0f, -angle - 90f, 0f);

        // Get Attack inputs
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            FireWeapon();
        }
    }

    private void FixedUpdate()
    {
        RB.MovePosition(RB.position + (movementVector * movementSpeed * Time.deltaTime));
    }

    public void FireWeapon()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
