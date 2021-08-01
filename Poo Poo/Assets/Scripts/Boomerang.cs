using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private Rigidbody2D rigid;

    [SerializeField]
    private float verticalPower = 0;
    [SerializeField]
    private float horizontalPower = 0;

    [SerializeField]
    private Vector2 returnPoint = new Vector2(0, 0);

    private bool stopReturn = false;  //  Stops boomerang return physics


    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    


    private void FixedUpdate()
    {
        if (!stopReturn)
        {
            ReturnToThrower();
        }
    }



    void ReturnToThrower()
    {
        //
        // Vertical
        // Above target
        //
        if (transform.position.y > returnPoint.y + 1.5)
        {
            //verticalPower = Mathf.Abs(returnPoint.y - transform.position.y) * .5f;
            rigid.AddForce(new Vector2(0, -1) * verticalPower);
        }

        // If close and going too fast, slow down
        else if ((transform.position.y > returnPoint.y) && (Mathf.Abs(rigid.velocity.y) > .5))
        {
            //rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
            //rigid.AddForce(new Vector2(0, 1) * verticalPower * 2.5f);
            //Debug.Log("slow");
            rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * .95f);
        }

        //If close, give force towards the player
        else if (transform.position.y > returnPoint.y)
        {
            rigid.AddForce(new Vector2(0, -1) * .5f);
            //rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * .95f);
        }

        //
        // Below target
        //
        else if (transform.position.y < returnPoint.y - 1.5)
        {
            //verticalPower = Mathf.Abs(returnPoint.y - transform.position.y) * .5f;
            rigid.AddForce(new Vector2(0, 1) * verticalPower);
        }

        // If close and going too fast, slow down
        else if ((transform.position.y < returnPoint.y) && (Mathf.Abs(rigid.velocity.y) > .5))
        {
            //rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
            //rigid.AddForce(new Vector2(0, -1) * verticalPower * 2.5f);
            //Debug.Log("slow");
            rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y * .95f);
        }

        // If close, give force towards the player
        else if (transform.position.y < returnPoint.y)
        {
            rigid.AddForce(new Vector2(0, 1) * .5f);
        }

        //// move to targets
        //Vector2 forceDirection = returnPoint - new Vector2(transform.position.x, transform.position.y);
        //rigid.AddForce(forceDirection * .5f);




        //
        // Horizontal
        // Left of target
        //
        if (transform.position.x > returnPoint.x)
        {
            horizontalPower = Mathf.Abs(returnPoint.x - transform.position.x) * .25f;
            rigid.AddForce(new Vector2(-1, 0) * horizontalPower);
        }

        //
        // Right of target
        //
        else if (transform.position.x < returnPoint.x)
        {
            horizontalPower = Mathf.Abs(returnPoint.x - transform.position.x) * .25f;
            rigid.AddForce(new Vector2(1, 0) * horizontalPower);
        }
    }
}
