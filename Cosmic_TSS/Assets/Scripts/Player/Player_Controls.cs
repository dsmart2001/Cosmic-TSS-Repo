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
        movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            movementVector /= 1.5f;
        }

        // Aim inputs
        AimInput = PI.actions["Aim"].ReadValue<Vector2>();

        // Get Attack inputs
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            FireWeapon();
        }

        /*
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        */

        // Transform towards mou
        //float angle = Vector2.Angle(Vector2.zero, AimInput);
        //float angle = Mathf.Acos(AimInput.x);
        float angle = AngleBetweenTwoPoints(Vector2.zero, AimInput);

        Debug.Log(angle);

        transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //new Quaternion.new Vector3(0f, angle * aimSpeed * Time.deltaTime, 0f));
        
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        RB.MovePosition(RB.position + (movementVector * movementSpeed * Time.deltaTime));
    }

    public void FireWeapon()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
        //Physics.IgnoreCollision(Bullet.GetComponent<Collider>(), CLDR, true);
    }
}
