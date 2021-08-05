using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{

    Rigidbody2D body;

    [SerializeField]
    private float throwForce = 200;

    [SerializeField]
    private KeyCode angleUp;
    [SerializeField]
    private KeyCode angleDown;
    [SerializeField]
    private KeyCode launchButton;

    private bool launch = false;
    private bool launched = false;
    private bool up = false;
    private bool down = false;

    [SerializeField]
    private float rotateInterval = 1f;

    // Trigger that the boomerang stops in
    public GameObject catchZone;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks for inputs here and completes functionality of those inputs in fixedupdate
        if(Input.GetKeyDown(launchButton))
        {
            launch = true;
        }

        if(Input.GetKey(angleUp))
        {
            up = true;
        }

        if(Input.GetKey(angleDown))
        {
            down = true;
        }
    }


    void FixedUpdate()
    {
        if (launch == true && launched != true)
        {
            body.AddForce(transform.up * throwForce);
            launch = false;
            launched = true;
        }

        if (up == true && launched != true)
        {
            double angle = (gameObject.transform.rotation.eulerAngles.z + 360) % 360;
            if((angle + rotateInterval) <= 360)
            {
                transform.Rotate(0.0f, 0.0f, rotateInterval);
            }
            up = false;
        }
        else if(down == true && launched != true)
        {
            double angle = (gameObject.transform.rotation.eulerAngles.z + 360) % 360;
            if((angle - rotateInterval) >= 270)
            {
                transform.Rotate(0.0f, 0.0f, -rotateInterval);
            }
            down = false;
        }
    }


    // Function to set variable back when boomerang is caught
    public void Caught()
    {
        launched = false;
        body.velocity = Vector2.zero;
        transform.position = catchZone.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == catchZone)
        {
            Caught();
        }
        else if(collision.gameObject.tag == "Bird")
        {
            // Slows down when it hits a bird
            body.velocity = body.velocity*0.75f;
        }
    }
}
