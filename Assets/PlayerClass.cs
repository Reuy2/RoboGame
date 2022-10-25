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
        StartPosition = new Vector3(StartPositionX, StartPositionY, 0f);
        player = PreFab;
        player.transform.position = StartPosition;
    }
    void Move(float x, float y)
    {
        player.transform.Translate(x * speed, y * speed, 0f);
    }
    public void Control()
    {
        Move(Input.GetAxis("Vertical"), -Input.GetAxis("Horizontal"));
    }

}
