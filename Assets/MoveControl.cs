using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{

    float _angle = 0f;
    float time = 0f;
    GameObject _helthBar, PlayerObject, PlayerPref;
    Player _player;
    bool ShiftEnable = true; 

    public static bool OnCommandPoint = false;
    public static float Boost = 1;
    public static bool _shipcontrol = true;

    public CooldownBoostTimer BoostTimer;

    [SerializeField]
    int _angleLimit = 100;
    [SerializeField]
    float _animationSpeed = 0.1f;
    [SerializeField]
    GameObject PlayerPreference;

    // Start is called before the first frame update
    void Start()
    {
        _helthBar = GameObject.Find("HelthBar");
        PlayerPref = PlayerPreference;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        BG_Scroller.y = Input.GetAxis("Vertical") / 100;
        BoostControl();
        CumSwitch();
        UpDownShip();
    }

    void BoostControl()
    {
        if (Boost >= 2)
            Boost -= 1f;
        if (!_shipcontrol)
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && _shipcontrol && PlayerObject == null)
        {
            PlayerPref = PlayerPreference;
            _helthBar.SetActive(false);
            _shipcontrol = false;
            PlayerPref = Instantiate(PlayerPref);

            _player = new Player(PlayerPref, 5.04f, 0.00f, 0.04f);
            PlayerObject = GameObject.Find("Player(Clone)");

            if (ShiftEnable)
            {
                ShiftEnable = false;
                StartCoroutine(Uncover(PlayerObject));
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && !_shipcontrol && ShiftEnable && OnCommandPoint)
        {
            CoverShip();
        }
        if (!_shipcontrol && PlayerObject!=null)
        {
            BG_Scroller.y = 0;
            _player.Control(); 
        }
        
    }

    void CoverShip()
    {
        ShiftEnable = false;
        StartCoroutine(Cover(PlayerObject));
        _shipcontrol = true;
    }

    IEnumerator Cover(GameObject player, float time = 0f)
    {
        while (time < 3f)
        {
            SpriteRenderer sprite = GameObject.Find("ShipUncovered").GetComponent<SpriteRenderer>();
            Color transp = sprite.color;
            yield return new WaitForEndOfFrame();

            transp.a = Mathf.Lerp(1, 0, time/3f);
            sprite.color = transp;

            PlayerAppear(false, time, player);
            
            time += Time.deltaTime;
        }
        ShiftEnable = true;
        Destroy(PlayerObject);
    }

    IEnumerator Uncover(GameObject player, float time = 0f)
    {
        while (time < 3f)
        {
            SpriteRenderer sprite = GameObject.Find("ShipUncovered").GetComponent<SpriteRenderer>();
            Color transp = sprite.color;
            yield return new WaitForEndOfFrame();

            transp.a = Mathf.Lerp(0, 1, time/3f);
            sprite.color = transp;

            PlayerAppear(true, time, player);

            time += Time.deltaTime;
        }
        ShiftEnable = true;
    }

    void PlayerAppear(bool appear, float time, GameObject player)
    {
        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        Color transp = sr.color;
        if (appear)
            transp.a = Mathf.Lerp(0, 1, time / 3f);
        else
            transp.a = Mathf.Lerp(1, 0, time / 3f);
        sr.color = transp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject == GameObject.Find("Ship") && collision.gameObject == PlayerObject)
            OnCommandPoint = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnCommandPoint = false;
    }
}
