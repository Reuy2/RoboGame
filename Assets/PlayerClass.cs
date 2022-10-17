using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    GameObject player;
    Vector3 StartPosition;
    float speed;
    float _estimatedTime = 0;
    Color _transp;
    SpriteRenderer _sr;
    public Player(GameObject PreFab, float StartPositionX, float StartPositionY, float speed)
    {
        this.speed = speed;
        this.StartPosition = new Vector3(StartPositionX, StartPositionY, 0f);
        player = PreFab;
        player.transform.position = StartPosition;
    }
    void Move(float x, float y)
    {
        player.transform.Translate(x * speed, y * speed, 0f);
    }

    void Initiate()
    {
        _transp = player.GetComponent<SpriteRenderer>().color;
        _sr = player.GetComponent<SpriteRenderer>();
    }
    public void Appear()
    {
        if (_estimatedTime == 0)
            Initiate();
        if (_estimatedTime < 5f)
        {
            _transp.a = Mathf.Lerp(0, 1, _estimatedTime);
            _estimatedTime += Time.deltaTime;
        }
        _sr.color = _transp;
    }
    public void Control()
    {
        Move(Input.GetAxis("Vertical"), -Input.GetAxis("Horizontal"));
    }
}
