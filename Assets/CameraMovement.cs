using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] MoveControl Ship;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _shipUncovered;

    Vector3 _upperFinish = new Vector3(0f, -4f, -685.8f);
    Vector3 _lowerFinish = new Vector3(0f, 4f, -685.8f);
    Vector3 _zeroFinish = new Vector3(0f, 0f, -685.8f);

    float _camStartPos = -685.8f;
    float _camEndPos = -200f;
    float _camLerpDuration = 3f;
    float _timeElapsed = 0f;

    private bool changeAllow = true;

    // Update is called once per frame
    void Update()
    {
        CameraMovementControl();
    }

    private void CameraMovementControl()
    {
        if(Ship.IsShipControl() == true && Input.GetKeyDown(KeyCode.LeftShift) && changeAllow == true)
        {
            Ship.ShipControlChangeToFalse();
            _playerMovement.MovementAllowChangeToTrue();
            changeAllow = false;
            StartCoroutine(CamToMinDistance());
            StartCoroutine(Uncover());
            return;
        }

        if(Ship.IsShipControl() == false && Input.GetKeyDown(KeyCode.LeftShift) && changeAllow == true)
        {
            Ship.ShipControlChangeToTrue();
            _playerMovement.MovementAllowChangeToFalse();
            changeAllow = false;
            StartCoroutine(CamToMaxDistance());
            StartCoroutine(Cover());
            return;
        }
    }
    
    IEnumerator CamToMaxDistance(float time = 0f)
    {
        transform.parent = null;
        while (time < _camLerpDuration)
        {
            yield return new WaitForEndOfFrame();
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(_camEndPos, _camStartPos, time / _camLerpDuration));
            time += Time.deltaTime;
        }
        _timeElapsed = 0;
        changeAllow = true;
        print(changeAllow);
    }

    IEnumerator CamToMinDistance(float time = 0f)
    {
        transform.parent = _player.transform;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        while (time < _camLerpDuration)
        {
            yield return new WaitForEndOfFrame();
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(transform.rotation.z, 0f, time / _camLerpDuration));
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, _player.transform.position.x, time / _camLerpDuration), Mathf.Lerp(transform.position.y, _player.transform.position.y, time / _camLerpDuration), Mathf.Lerp(_camStartPos, _camEndPos, time / _camLerpDuration));
            time += Time.deltaTime;
        }
        _timeElapsed = 0;
        changeAllow = true;
        print(changeAllow);
    }

    IEnumerator Cover(float time = 0f)
    {
        SpriteRenderer shipTransp = _shipUncovered.GetComponent<SpriteRenderer>();
        SpriteRenderer playerTransp = _player.GetComponent<SpriteRenderer>();
        while (time < _camLerpDuration)
        {
            SpriteRenderer[] childList = _shipUncovered.GetComponentsInChildren<SpriteRenderer>();
            Color transp = shipTransp.color;
            yield return new WaitForEndOfFrame();

            transp.a = Mathf.Lerp(1, 0, time / _camLerpDuration);
            shipTransp.color = transp;
            playerTransp.color = transp;
            foreach (SpriteRenderer i in childList)
            {
                i.color = transp;
            }

            time += Time.deltaTime;
        }
    }

    IEnumerator Uncover(float time = 0f)
    {
        SpriteRenderer shipTransp = _shipUncovered.GetComponent<SpriteRenderer>();
        SpriteRenderer playerTransp = _player.GetComponent<SpriteRenderer>();
        while (time < _camLerpDuration)
        {
            SpriteRenderer[] childList = _shipUncovered.GetComponentsInChildren<SpriteRenderer>();
            Color transp = shipTransp.color;
            yield return new WaitForEndOfFrame();

            transp.a = Mathf.Lerp(0, 1, time / _camLerpDuration);
            shipTransp.color = transp;
            playerTransp.color = transp;
            foreach (SpriteRenderer i in childList)
            {
                i.color = transp;
            }


            time += Time.deltaTime;
        }
    }
}
