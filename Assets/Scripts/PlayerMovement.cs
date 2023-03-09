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

    [SerializeField] float deadZone = 0.1f;

    private bool isMovementAllow = false;
    private string warningName = null;

    public bool onCommandPoint = true;
    public bool onTriggerWarning = false;

    private void Update()
    {
        float angle = Vector2.Angle(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), new Vector2(0, 1));
        Console.WriteLine(angle);
        if (MovementAllow())
        {
            DirectionCapture();
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


    private void DirectionCapture()
    {
        float angle;
        if (Input.GetAxis("Horizontal") <0 && Math.Abs(Input.GetAxis("Horizontal")) + Math.Abs(Input.GetAxis("Vertical")) > deadZone)
        {
            angle = Vector2.Angle(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), new Vector2(0, 1));
            transform.rotation = Quaternion.Euler(0, 0, angle+180);
            animPlayer.SetBool("move", true);
        }
        else if(Input.GetAxis("Horizontal") >= 0 && Math.Abs(Input.GetAxis("Horizontal"))+ Math.Abs(Input.GetAxis("Vertical")) > deadZone)
        {
            angle = Vector2.Angle(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")), new Vector2(0, -1));
            transform.rotation = Quaternion.Euler(0, 0, angle);
            animPlayer.SetBool("move", true);
        }
        else if(Math.Abs(Input.GetAxis("Horizontal")) + Math.Abs(Input.GetAxis("Vertical")) <= deadZone)
        {
            animPlayer.SetBool("move", false);
        }


        /*if (Input.GetAxis("Horizontal") < 1 && Input.GetAxis("Horizontal") > -1 && Input.GetAxis("Vertical") < 1 && Input.GetAxis("Vertical") > -1)
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
        */

    }

    private void MovementStop()
    {
        _rb.velocity = new Vector2(0f, 0f);
    }

    private void MovementLogic()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"))*_speed;
    }

    public void MovementAllowChangeToFalse()
    {
        isMovementAllow = false;
        animPlayer.enabled = false;
    }

    public void MovementAllowChangeToTrue()
    {
        isMovementAllow = true;
        animPlayer.enabled = true;
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
