using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;
    [SerializeField] private Rigidbody2D _rb;

    private bool isMovementAllow = false;

    public bool onCommandPoint;
    public bool onTriggerWarning;
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

    public void MovementAllowChange()
    {
        isMovementAllow = !isMovementAllow;
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onCommandPoint = false;
        onTriggerWarning = false;
    }
}
