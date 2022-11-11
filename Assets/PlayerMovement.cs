using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject circleOnCenterGame;
    [SerializeField] private TriggerMiniGame _triggerControl;

    private bool isMovementAllow = false;
    private string warningName = null;

    public bool onCommandPoint = true;
    public bool onTriggerWarning = false;
    // переделать вызов мини игры по нормальному
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && onTriggerWarning)
        { 
            //Тут добавлять запуск игры
            if(warningName == "CircleInCenter(Clone)" && _triggerControl.CountGame() == 0)
            {
                Instantiate<GameObject>(circleOnCenterGame);
            }
        }
    }
    void FixedUpdate()
    {
        if (isMovementAllow)
        {
            MovementLogic();
        }
        else
        {
            MovementStop();
        }
    }

    private void MovementStop()
    {
        _rb.velocity = new Vector2(0f, 0f);
    }

    private void MovementLogic()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public void MovementAllowChangeToFalse()
    {
        isMovementAllow = false;
    }

    public void MovementAllowChangeToTrue()
    {
        isMovementAllow = true;
    }

    public bool MovementAllow()
    {
        return isMovementAllow;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ship")
        {
            onCommandPoint = true;
        }

        if (collision.gameObject.tag == "TriggerWarning")
        {
            onTriggerWarning = true;
        }
        warningName = collision.name;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onCommandPoint = false;
        onTriggerWarning = false;
        warningName = null;
    }
}
