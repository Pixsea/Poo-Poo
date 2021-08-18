using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField]
    private GameObject boomerangSprite;  // Sprite to enable and disable
    [SerializeField]
    private GameObject aimingReticle;  // Reticle to enable and disable

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

    [SerializeField]
    private Animator monkeyAnimator;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        aimingReticle.SetActive(true);
        boomerangSprite.SetActive(false);
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
            // Throw()
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
        aimingReticle.SetActive(true);
        boomerangSprite.SetActive(false);
        body.velocity = Vector2.zero;
        transform.position = catchZone.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }


    //  Thorw boomerang with a given amount of charge
    public void ThrowBoomerang(float charge)
    {
        body.AddForce(transform.up * throwForce * 2 * charge);
        //launch = false;
        launched = true;
        aimingReticle.SetActive(false);
        boomerangSprite.SetActive(true);
        monkeyAnimator.SetTrigger("Throw");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == catchZone)
        {
            Caught();
        }
        else if(collision.gameObject.tag == "Bird")
        {
            // Debug.Log("Boomerang Contact Bird");
            // Slows down when it hits a bird
            body.velocity = body.velocity*0.75f;
        }
        else if(collision.gameObject.tag == "Plane")
        {
            // Debug.Log("Boomerang Contact Plane");
            // boomerang shot back
            body.velocity = body.velocity*-1f;
        }
    }
}
