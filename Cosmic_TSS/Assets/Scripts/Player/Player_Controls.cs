using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    /*
     * 
     */

    // Player objects and components
    private Rigidbody RB => GetComponent<Rigidbody>();
    private Collider CLDR => GetComponent<Collider>();
    public GameObject Bullet;

    // Player stats
    private Vector3 movementVector;
    public float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            movementVector /= 1.5f;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }

        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
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
        Physics.IgnoreCollision(Bullet.GetComponent<Collider>(), CLDR, true);
    }
}
