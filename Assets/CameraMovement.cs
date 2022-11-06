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
    float _camEndPos = -200f;
    float _camLerpDuration = 3f;
    float _timeElapsed = 0f;
    bool _shipControl = true;
    bool cam_locked = false;

    // Update is called once per frame
    void FixedUpdate()
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
        if (Input.GetKey(KeyCode.LeftShift) && _timeElapsed < 3)
        {
            _shipControl = false;
        }
        if (_timeElapsed < _camLerpDuration && !_shipControl && !cam_locked)
        {
            transform.parent = GameObject.FindWithTag("Player").transform;
            transform.position = new Vector3(GameObject.FindWithTag("Player").transform.position.x, GameObject.FindWithTag("Player").transform.position.y, Mathf.Lerp(_camStartPos, _camEndPos, _timeElapsed / _camLerpDuration));
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            _timeElapsed += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift) && !_shipControl && _timeElapsed >=3 && MoveControl.OnCommandPoint)
        {
            _shipControl = true;
            StartCoroutine(CamToMaxDistance(0f));
        }
        return !_shipControl;
    }
    
    IEnumerator CamToMaxDistance(float time)
    {
        cam_locked = true;
        transform.parent = null;
        while (time < _camLerpDuration)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(0f, 0f, Mathf.Lerp(_camEndPos, _camStartPos, time / _camLerpDuration));
            time += Time.deltaTime;
        }
        _timeElapsed = 0;
        cam_locked = false;
    }
}
