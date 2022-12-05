using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScroller : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.localPosition.x > 870f || transform.localPosition.x < -800f)
        {
            transform.Translate((-3f * Mathf.Sqrt(MoveControl.Boost) * Time.deltaTime), 0, 0);
        }
        else
        {
            transform.Translate((-1f * Mathf.Sqrt(MoveControl.Boost) * Time.deltaTime), 0, 0);
        }

        
    }
}
