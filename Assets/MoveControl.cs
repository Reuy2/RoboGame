using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    float _angle = 0;

    public static float Boost = 1;

    bool _shipcontrol = true;
    public CooldownBoostTimer BoostTimer;

    [SerializeField]
    int _angleLimit = 100;

    float CooldownTime = 5;

    [SerializeField]
    float _animationSpeed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        BG_Scroller.y = Input.GetAxis("Vertical") / 100;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _shipcontrol = false;
        }
        if (!_shipcontrol)
        {
            BG_Scroller.y = 0;
        }
        
        BoostControl();

        if (Input.GetKey(KeyCode.W) && _shipcontrol)
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

        if (Input.GetKey(KeyCode.S) && _shipcontrol)
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

    void BoostControl()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CooldownTime <= 0)
        {
            Boost = 100;
            CooldownTime = 5;
            BoostTimer.SetScale(0);
        }
        else if (Boost >= 2)
        {
            Boost -= 1f;
        }

        if(CooldownTime > 0)
        {
            CooldownTime -= Time.deltaTime;
            BoostTimer.SetScale(5 - CooldownTime);
        }
    }
}
