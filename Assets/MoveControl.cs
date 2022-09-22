using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    float speedUp = 0;
    float angle = 0;

    

    [SerializeField]
    int AngleLimit = 100;

    [SerializeField]
    float AnimationSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);
        transform.Translate(Vector3.up * speedUp * Time.deltaTime);
        BG_Scroller.y = speedUp/1000;

        if (Input.GetKey(KeyCode.W) && speedUp < 5) 
        {
            speedUp += 1;
        }
        else if (Input.GetKey(KeyCode.S) && speedUp > -5)
        {
            speedUp -= 1;
        }
        else if (speedUp > 0) 
        { 
            speedUp -= 1; 
        
        }
        else if (speedUp < 0)
        {
            speedUp += 1;

        }

        if (Input.GetKey(KeyCode.W))
        {
            if(angle < AngleLimit)
            {
                transform.Rotate(Vector3.forward, AnimationSpeed);
                angle += 1;
            }
        }
        else
        {
            if (angle > 0)
            {
                transform.Rotate(Vector3.forward, -AnimationSpeed);
                angle -= 1;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (angle > -AngleLimit)
            {
                transform.Rotate(Vector3.forward, -AnimationSpeed);
                angle -= 1;
            }
        }
        else
        {
            if (angle < 0)
            {
                transform.Rotate(Vector3.forward, +AnimationSpeed);
                angle += 1;
            }
        }


    }
}
