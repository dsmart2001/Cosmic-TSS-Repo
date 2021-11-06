using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player_Controls : MonoBehaviour
{
    /*
     * 
     */

    // Player objects and components
    private Rigidbody RB => GetComponent<Rigidbody>();
    private Collider CLDR => GetComponent<Collider>();
    private PlayerInput PI => GetComponent<PlayerInput>();

    public static bool phoneControls = true;

    public Camera playerCamera;

    // Player Weapons
    [Header("Player Weapons")]

    public Weapon_PlayerGuns[] weapons;
    public static Weapon_PlayerGuns equippedWeapon;
    public TMP_Text ammoUI;
    private int weaponNum = 0;

    // Player movement values
    [Header("Player Movement values")]

    private Vector2 AimInput;
    private Vector3 movementVector;
    public float movementSpeed;

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
            AimInput = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else
        {
            movementVector = new Vector3(PI.actions["Move"].ReadValue<Vector2>().x, 0f, PI.actions["Move"].ReadValue<Vector2>().y);
            AimInput = PI.actions["Aim"].ReadValue<Vector2>();
        }

        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            movementVector /= 1.5f;
        }

        // Aim inputs
        Vector2 playerScreenPos = playerCamera.WorldToScreenPoint(transform.position);

        // Check if Movement joystick is being read and not Aim joystick to let movestick control rotation
        if(phoneControls && PI.actions["Aim"].ReadValue<Vector2>() != Vector2.zero )
        {
            float angle = AngleBetweenTwoPoints(Vector2.zero, AimInput);

            transform.rotation = Quaternion.Euler(0f, -angle - 90f, 0f);
        }
        else if(!phoneControls)
        {
            float angle = AngleBetweenTwoPoints(playerScreenPos, AimInput);
            Debug.Log("Cursor Position: " + playerScreenPos);
            transform.rotation = Quaternion.Euler(0f, -angle - 90f, 0f);
        }

        // Get Attack inputs
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            FireWeapon();
        }

        // Swap weapon
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwapWeapon();
        }

        ammoUI.text = equippedWeapon.ammo.ToString();

        RB.MovePosition(RB.position + (movementVector * movementSpeed * Time.deltaTime));

    }

    private void FixedUpdate()
    {
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    // Function to fire the current equipped weapon
    public void FireWeapon()
    {
        equippedWeapon.FireWeapon();
    }

    // Swap from the given weapons of player
    public void SwapWeapon()
    {
        if(weaponNum != weapons.Length - 1)
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
