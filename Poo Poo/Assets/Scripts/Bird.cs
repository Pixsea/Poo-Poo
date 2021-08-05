using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    // Make Bird move constantly
    // Bird Movement: either move back and forth or some seemingly offscreen movement later

    [SerializeField]
    private float birdSpeed = 1f;
    [SerializeField]
    private float fallSpeed = 3f;

    Rigidbody2D body;
    SpriteRenderer m_SpriteRenderer;
    Animator animator;

    [SerializeField]
    private float timeCountdown = 5;
    private float currentTime = 1;

    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentTime = timeCountdown;
    }

    void birdDeath()
    {
        // add falling animation
        // make bird go down to ground
        dead = true;
        //body.velocity = new Vector2(0, fallSpeed);
        body.gravityScale = fallSpeed;
        animator.Play("Bird_Death");
    }

    void FixedUpdate()
    {
        if (!dead)
        {
            // make bird move
            body.velocity = new Vector2(birdSpeed, body.velocity.y);

            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                // Change direction of bird and reset timer
                birdSpeed = birdSpeed * -1;
                currentTime = timeCountdown;

                // flips sprite
                if(!m_SpriteRenderer.flipX)
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
        if(collision.gameObject.tag == "Boomerang" && dead == false)
        {
            body.velocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            birdDeath();
        }

    }
}
