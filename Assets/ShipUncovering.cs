using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUncovering : MonoBehaviour
{
    Color transp;
    SpriteRenderer _sr;

    float estimatedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        transp = GetComponent<SpriteRenderer>().color;
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MoveControl._shipcontrol && estimatedTime<5f)
        {
            transp.a = Mathf.Lerp(0, 1, estimatedTime);
            _sr.color = transp;
            estimatedTime += Time.deltaTime;
        }
    }
}
