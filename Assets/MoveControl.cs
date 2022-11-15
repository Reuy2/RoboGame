using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{

    float _angle = 0f;

    GameObject PlayerObject;

    Player _player;

    bool ShiftEnable = true;

    public static bool OnCommandPoint = false;
    public static float Boost = 1;
    public static bool ship—ontrol = true;

    public CooldownBoostTimer BoostTimer;

    [SerializeField]
    int _angleLimit = 100;
    [SerializeField]
    float _animationSpeed = 0.1f;
    [SerializeField]
    PlayerMovement Player;
    [SerializeField]
    Transform Ship;



    void Update()
    {
        BoostControl();

        if (ship—ontrol)
        {
            BG_Scroller.y = Input.GetAxis("Vertical") / 100;
            UpDownShip();
        }
        else
        {
            BG_Scroller.y = 0;
            StraightShip();
        }
    }

    public void ShipControlChangeToTrue()
    {
        ship—ontrol = true;
    }

    public void ShipControlChangeToFalse()
    {
        ship—ontrol = false;
    }

    public bool IsShipControl()
    {
        return ship—ontrol;
    }

    void BoostControl()
    {
        if (Boost >= 2)
            Boost -= 1f;
        if (!ship—ontrol)
            return;
        if (Input.GetKey(KeyCode.Space) && BoostTimer.BoostCheck())
        {
            Boost = 100;
            BoostTimer.SetScale(-1000);
        }
    }

    void StraightShip()
    {
        if (_angle < 0)
        {
            transform.Rotate(Vector3.forward, +_animationSpeed);
            _angle += 1;
        }
        if (_angle > 0)
        {
            transform.Rotate(Vector3.forward, -_animationSpeed);
            _angle -= 1;
        }
    }

    void UpDownShip()
    {
        if (!ship—ontrol)
        {
            StraightShip();
            return;
        }

        if (_angle < _angleLimit && Input.GetAxis("Vertical") > 0)
        {
            transform.Rotate(Vector3.forward, _animationSpeed);
            _angle += 1;
        }
        else if (_angle > -_angleLimit && Input.GetAxis("Vertical") < 0)
        {
            transform.Rotate(Vector3.forward, -_animationSpeed);
            _angle -= 1;
        }
        else if(Input.GetAxis("Vertical") == 0)
        {
            StraightShip();
        }
    }

   
}
