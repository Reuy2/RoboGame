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

    [SerializeField] Animator animPlayer;

    private bool isMovementAllow = false;
    private string warningName = null;

    public bool onCommandPoint = true;
    public bool onTriggerWarning = false;

    private void Update()
    {
        DirectionCapture();
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


    private void DirectionCapture()
    {
        if (Input.GetAxis("Horizontal") < 1 && Input.GetAxis("Horizontal") > -1 && Input.GetAxis("Vertical") < 1 && Input.GetAxis("Vertical") > -1)
        {
            animPlayer.SetInteger("direction", 0);
        }

        if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 1 && Input.GetAxis("Vertical") > -1)
        {
            animPlayer.SetInteger("direction", 2);
        }

        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 1 && Input.GetAxis("Vertical") > -1)
        {
            animPlayer.SetInteger("direction", 3);
        }

        if ( Input.GetAxis("Vertical") > 0)
        {
            animPlayer.SetInteger("direction", 4);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            animPlayer.SetInteger("direction", 1);
        }
    }

    private void MovementStop()
    {
        _rb.velocity = new Vector2(0f, 0f);
        animPlayer.SetInteger("direction",0);
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
