using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")/20, Input.GetAxis("Vertical")/20, 0f);
    }
}
