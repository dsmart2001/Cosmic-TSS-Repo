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

    // Player Weapons
    public Weapon_PlayerGuns[] weapons;
    private Weapon_PlayerGuns equippedWeapon;
    private int weaponNum = 0;

    // Player movement values
    private Vector2 AimInput;
    private Vector3 movementVector;
    public float movementSpeed;
    public float aimSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Assign weapons at start
        foreach(Weapon_PlayerGuns gun in weapons)
        {
            gun.gameObject.SetActive(false);
        }

        equippedWeapon = weapons[weaponNum];
        equippedWeapon.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Get Movement inputs, if using onscreen joysticks allow them to control character, otherwise use keyboard (For playtesting on computer)
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

        // Check if Movement joystick is being read and not Aim joystick to let movestick control rotation
        if(PI.actions["Aim"].ReadValue<Vector2>() != Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(0f, -angle - 90f, 0f);
        }
        else if(PI.actions["Aim"].ReadValue<Vector2>() == Vector2.zero && PI.actions["Aim"].ReadValue<Vector2>() != Vector2.zero)
        {
            float angle2 = AngleBetweenTwoPoints(Vector2.zero, PI.actions["Aim"].ReadValue<Vector2>());

            transform.rotation = Quaternion.Euler(0f, -angle2 - 90f, 0f);
        }

        // Get Attack inputs
        if (Input.GetKeyDown(KeyCode.Space))
        {
            equippedWeapon.FireWeapon();
        }

        // Swap weapon
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwapWeapon();
        }
    }

    private void FixedUpdate()
    {
        RB.MovePosition(RB.position + (movementVector * movementSpeed * Time.deltaTime));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void SwapWeapon()
    {
        if(weaponNum != weapons.Length)
        {
            equippedWeapon.gameObject.SetActive(false);
            weaponNum++;
            equippedWeapon = weapons[weaponNum];
            equippedWeapon.gameObject.SetActive(true);
        }
        else
        {
            equippedWeapon.gameObject.SetActive(false);
            weaponNum = 0;
            equippedWeapon = weapons[weaponNum];
            equippedWeapon.gameObject.SetActive(true);
        }
    }
}
