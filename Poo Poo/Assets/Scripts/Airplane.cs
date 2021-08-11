using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{

    [SerializeField]
    private float planeSpeed = 1f;

    Rigidbody2D body;
    SpriteRenderer m_SpriteRenderer;

    [SerializeField]
    private float timeCountdown = 5;
    private float currentTime = 1;

    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        currentTime = timeCountdown;
    }

    void planeCrash()
    {
        //Debug.Log("Plane hit!");
        dead = true;
        // for now, plane does not move
        body.velocity = new Vector2(0,0);
    }

    public bool isDead()
    {
        return dead;
    }

    void FixedUpdate()
    {
        if (!dead)
        {
            // make bird move
            body.velocity = new Vector2(planeSpeed, body.velocity.y);

            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                // Change direction of bird and reset timer
                planeSpeed = planeSpeed * -1;
                currentTime = timeCountdown;

                // flips sprite
                if (!m_SpriteRenderer.flipX)
                {
                    m_SpriteRenderer.flipX = true;
                }
                else
                {
                    m_SpriteRenderer.flipX = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // using tags for now but I can change it later if that would be better
        if (collision.gameObject.tag == "Boomerang" && dead == false)
        {
            // body.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            planeCrash();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }
}
