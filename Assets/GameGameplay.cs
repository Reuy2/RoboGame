using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameGameplay : MonoBehaviour
{
    [SerializeField]
     private float Timertime;

    [SerializeField] private GameObject triggerWarning;
    [SerializeField] private GameObject _miniGameWindow;

    [SerializeField]
    TMP_Text Text;

    float ElapsedTime;

    private TriggerMiniGame _triggerMiniGame;
    private PlayerMovement _player;
    // Start is called before the first frame update
    private void OnEnable()
    {
        ElapsedTime = 0;
        _triggerMiniGame = GameObject.Find("TriggerController").GetComponent<TriggerMiniGame>();
        _player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _player.MovementAllowChangeToFalse();
        _triggerMiniGame.CountGame(1);


    }

    // Update is called once per frame
    void Update()
    {
        ElapsedTime += Time.deltaTime;

        TextPrint();

        Timer();

        Direction();



    }

    void TextPrint()
    {
        if ((9 - Mathf.Ceil(ElapsedTime)) > 4)
        {
            Text.text = "Удерживай круг в центре еще " + (Timertime + 1 - Mathf.Ceil(ElapsedTime)) + " секунд.";
        }
        else if ((Timertime + 1 - Mathf.Ceil(ElapsedTime)) <= 4 && (Timertime + 1 - Mathf.Ceil(ElapsedTime)) > 1)
        {
            Text.text = "Удерживай круг в центре еще " + (Timertime + 1 - Mathf.Ceil(ElapsedTime)) + " секунды.";
        }
        else
        {
            Text.text = "Удерживай круг в центре еще " + (Timertime + 1 - Mathf.Ceil(ElapsedTime)) + " секунду.";
        }
    }

    void Timer()
    {
        if (ElapsedTime >= Timertime)
        {
            ElapsedTime = 0;
            _player.MovementAllowChangeToTrue();
            if (_triggerMiniGame.CountGame() == 1)
            {
                _triggerMiniGame.CountGame(-1);
            }
            //Destroy(GameObject.Find("CircleInCenter(Clone)"));
            //GameObject.Find("CircleInCenter")
            triggerWarning.SetActive(false);
            _miniGameWindow.SetActive(false);

        }
    }

    void Direction()
    {
        if (transform.position.x < 0.05f && transform.position.x > -0.05f)
        {
            transform.Translate(Random.Range(-0.1f, 0.1f), 0f, 0f);
        }

        if (transform.position.y < 0.05f && transform.position.y > -0.05f)
        {
            transform.Translate(0f, Random.Range(-0.1f, 0.1f), 0f);
        }

        float x1 = 0, y1 = 0;
        float x2 = transform.position.x, y2 = transform.position.y;
        float A = Mathf.Atan2(y1 - y2, x1 - x2) / Mathf.PI * 180;

        transform.Translate(Mathf.Sin(A) * Time.deltaTime, Mathf.Cos(A) * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player.MovementAllowChangeToTrue();
        //тут не вставлять починку поломки
        if (_triggerMiniGame.CountGame() == 1)
        {
            _triggerMiniGame.CountGame(-1);
        }
        _miniGameWindow.SetActive(false);
    }

    private void OnDisable()
    {
        transform.position = new Vector2(0f, 0f);
    }
}
