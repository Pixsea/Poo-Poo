using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSprite : MonoBehaviour
{
    public float totalTime;  // Time in second the sprite sould be on screen
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = totalTime;
    }

    void FixedUpdate()
    {
        if (timer <= 0)
        {
            DestroyObject(gameObject);
        }

        timer--;
    }
}
