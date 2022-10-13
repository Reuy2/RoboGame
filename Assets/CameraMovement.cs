using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float _cameraSpeedUpAndDown = 500f;
    [SerializeField]
    float _cameraToZeroSpeed = 500f;

    Vector3 _upperFinish = new Vector3(0f, -4f, -685.8f);
    Vector3 _lowerFinish = new Vector3(0f, 4f, -685.8f);
    Vector3 _zeroFinish = new Vector3(0f, 0f, -685.8f);

    float _camStartPos = -685.8f;
    float _camEndPos = -100f;
    float _camLerpDuration = 3f;
    float _timeElapsed = 0f;
    bool _shipControl = true;
    // Start is called before the first frame update
    void Start()
    {
     
    }


    // Update is called once per frame
    void Update()
    {
        if (IsPlayerControl())
        {
            return;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position = Vector3.Lerp(transform.position, _upperFinish, Input.GetAxis("Vertical") / _cameraSpeedUpAndDown);
        }
        if(Input.GetAxis("Vertical") == 0f)
        {
            transform.position = Vector3.Lerp(transform.position, _zeroFinish, 1f / _cameraToZeroSpeed);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position = Vector3.Lerp(transform.position, _lowerFinish, -Input.GetAxis("Vertical")/ _cameraSpeedUpAndDown);
        }
        
    }

    bool IsPlayerControl()
    {
        if (Input.GetKey(KeyCode.LeftShift) && _timeElapsed < 10)
        {
            _shipControl = false;
        }
        if (_timeElapsed < _camLerpDuration && !_shipControl)
        {
            transform.position = new Vector3(0f, 0f, Mathf.Lerp(_camStartPos, _camEndPos, _timeElapsed / _camLerpDuration));
            _timeElapsed += Time.deltaTime;
        }
        return !_shipControl;
    }
}
