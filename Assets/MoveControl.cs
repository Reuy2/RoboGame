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
        }
        else
        {
            BG_Scroller.y = 0;
        }
        CumSwitch();
        UpDownShip();
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

    void CumSwitch()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && ship—ontrol)
        {
            ShipControlChangeToFalse();
            Player.MovementAllowChangeToTrue();

            if (ShiftEnable)
            {
                ShiftEnable = false;
                StartCoroutine(Uncover(PlayerObject));
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && !ship—ontrol && ShiftEnable && Player.onCommandPoint)
        {
            CoverShip();
            ShipControlChangeToTrue();
            Player.MovementAllowChangeToFalse();
        }
        
    }

    void CoverShip()
    {
        ShiftEnable = false;
        StartCoroutine(Cover(PlayerObject));
    }

    IEnumerator Cover(GameObject player, float time = 0f)
    {
        GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("TriggerWarning");
        SpriteRenderer shipTransp = GameObject.Find("ShipUncovered").GetComponent<SpriteRenderer>();
        SpriteRenderer playerTransp = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        while (time < 3f)
        {
            Color transp = shipTransp.color;
            yield return new WaitForEndOfFrame();

            transp.a = Mathf.Lerp(1, 0, time/3f);
            shipTransp.color = transp;
            playerTransp.color = transp;
            foreach (GameObject i in ObjectList)
            {
                SpriteRenderer Render = i.GetComponent<SpriteRenderer>();
                Render.color = transp;
            }

            time += Time.deltaTime;
        }
        ShiftEnable = true;
    }

    IEnumerator Uncover(GameObject player, float time = 0f)
    {
        GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("TriggerWarning");
        SpriteRenderer shipTransp = GameObject.Find("ShipUncovered").GetComponent<SpriteRenderer>();
        SpriteRenderer playerTransp = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        while (time < 3f)
        {
            Color transp = shipTransp.color;
            yield return new WaitForEndOfFrame();

            transp.a = Mathf.Lerp(0, 1, time/3f);
            shipTransp.color = transp;
            playerTransp.color = transp;
            foreach (GameObject i in ObjectList)
            {
                SpriteRenderer Render = i.GetComponent<SpriteRenderer>();
                Render.color = transp;
            }


            time += Time.deltaTime;
        }
        ShiftEnable = true;
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (gameObject == GameObject.Find("Ship") && collision.gameObject == PlayerObject)
    //        OnCommandPoint = true;
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    OnCommandPoint = false;
    //}
}
