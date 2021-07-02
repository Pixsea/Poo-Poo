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
        //if (transform.position.y > returnPoint.y + 2)
        //{
        //    rigid.AddForce(new Vector2(0, -1) * verticalPower);
        //}
        //else if (transform.position.y > returnPoint.y)
        //{
        //    rigid.AddForce(new Vector2(0, -1) * verticalPower/2);
        //}
        //else if (transform.position.y < returnPoint.y - 2)
        //{
        //    rigid.AddForce(new Vector2(0, 1) * verticalPower);
        //}
        //else if (transform.position.y < returnPoint.y)
        //{
        //    rigid.AddForce(new Vector2(0, 1) * verticalPower/2);
        //}
    }
}
