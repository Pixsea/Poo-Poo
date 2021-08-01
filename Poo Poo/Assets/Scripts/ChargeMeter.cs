using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeMeter : MonoBehaviour
{
    [SerializeField]
    private KeyCode inputKey;

    [SerializeField]
    private Slider chargeMeter;
    private bool meterActive = false;  // Whether the meter should be moving
    private bool meterIncreasing = true;  // Whether the meter is currently icnreasing in value

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inputKey) && !meterActive)
        {
            chargeMeter.gameObject.SetActive(true);
            chargeMeter.value = 0;
            meterActive = true;
        }

        else if (Input.GetKeyDown(inputKey) && meterActive)
        {
            Debug.Log(chargeMeter.value);
            meterActive = false;
            StartCoroutine(DisableMeterAfterTime(1));
        }
    }


    private void FixedUpdate()
    {
        if (meterActive)
        {
            if (meterIncreasing)
            {
                chargeMeter.value += .1f;

                if (chargeMeter.value >= 1)
                {
                    meterIncreasing = false;
                }
            }
            else
            {
                chargeMeter.value -= .1f;

                if (chargeMeter.value <= 0)
                {
                    meterIncreasing = true;
                }
            }
        }
    }


    IEnumerator DisableMeterAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        chargeMeter.gameObject.SetActive(false);
    }
}
