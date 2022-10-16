using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{

    float _angle = 0;

    GameObject _helthBar;

    public static float Boost = 1;

    public static bool _shipcontrol = true;
    public CooldownBoostTimer BoostTimer;

    [SerializeField]
    int _angleLimit = 100;

    [SerializeField]
    float _animationSpeed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        _helthBar = GameObject.Find("HelthBar");
    }

    // Update is called once per frame
    void Update()
    {

        BoostControl();

        BG_Scroller.y = Input.GetAxis("Vertical") / 100;

        CumSwitch();

        UpDownShip();
    }


    void BoostControl()
    {
        if (!_shipcontrol)
            return;
        if (Input.GetKey(KeyCode.Space) && BoostTimer.BoostCheck())
        {
            Boost = 100;
            BoostTimer.SetScale(-1000);
        }
        else if (Boost >= 2)
        {
            Boost -= 1f;
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
        if (!_shipcontrol)
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
        else
            StraightShip();
    }

    void CumSwitch()
    {
        if (Input.GetKey(KeyCode.LeftShift) && _shipcontrol)
        {
            _shipcontrol = false;
            _helthBar.SetActive(false);
        }
        if (!_shipcontrol)
        {
            BG_Scroller.y = 0;
            StraightShip();
        }
    }

}
