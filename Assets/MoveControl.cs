using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    float _angle = 0;

    

    [SerializeField]
    int _angleLimit = 100;

    [SerializeField]
    float _animationSpeed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if(_angle < _angleLimit)
            {
                transform.Rotate(Vector3.forward, _animationSpeed);
                _angle += 1;
            }
        }
        else
        {
            if (_angle > 0)
            {
                transform.Rotate(Vector3.forward, -_animationSpeed);
                _angle -= 1;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (_angle > -_angleLimit)
            {
                transform.Rotate(Vector3.forward, -_animationSpeed);
                _angle -= 1;
            }
        }
        else
        {
            if (_angle < 0)
            {
                transform.Rotate(Vector3.forward, +_animationSpeed);
                _angle += 1;
            }
        }


    }
}
