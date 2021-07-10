using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField]
    private float verticalPower = 0;
    [SerializeField]
    private float horizontalPower = 0;

    [SerializeField]
    private Vector2 returnPoint = new Vector2(0, 0);


    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(rigid.velocity.y);

        if (transform.position.y > returnPoint.y + 1.5)
        {
            rigid.AddForce(new Vector2(0, -1) * verticalPower);
            Debug.Log("fast");
        }

        // If close and going too fast
        else if ((transform.position.y > returnPoint.y) && (Mathf.Abs(rigid.velocity.y) > .5))
        {
            //rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
            rigid.AddForce(new Vector2(0, 1) * verticalPower * 3);
            Debug.Log("slow");
        }

        else if (transform.position.y < returnPoint.y - 1.5)
        {
            rigid.AddForce(new Vector2(0, 1) * verticalPower);
            Debug.Log("fast");
        }

        // If close and going too fast
        else if ((transform.position.y > returnPoint.y) && (Mathf.Abs(rigid.velocity.y) > .5))
        {
            //rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
            rigid.AddForce(new Vector2(0, -1) * verticalPower * 3);
            Debug.Log("slow");
        }

        Vector2 forceDirection = returnPoint - new Vector2(transform.position.x, transform.position.y);
        rigid.AddForce(forceDirection * verticalPower);
    }
}
