using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System;

public class LampBuutons : MonoBehaviour
{
    int correct = 0;

    List<string> buttonList = new List<string>() { "Yellow", "Green", "Blue", "Red" };
    List<Color> colorList = new List<Color>() { Color.yellow, Color.green, Color.blue, Color.red };
    PlayerMovement player;
    TriggerMiniGame trigger;
    enum Btn 
    {
        Yellow,
        Green,
        Blue,
        Red
    }

    enum keyboard_to_color
    {
        Yellow = KeyCode.Y,
        Green = KeyCode.G,
        Blue = KeyCode.B,
        Red = KeyCode.R
    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        player.MovementAllowChangeToFalse();
        trigger.CountGame(1);

        buttonList = ShuffleList(buttonList);
        StartCoroutine(Lights());
    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();
    }

    void InputCheck()
    {
        var a = (keyboard_to_color)Enum.Parse(typeof(keyboard_to_color), buttonList[correct]);
        if (Input.GetKey((KeyCode)a))
        {
            correct += 1;
        }
        else if (!Input.GetKey(KeyCode.None))
        {
            correct = 0;
        }
    }


    List<string> ShuffleList(List<string> list)
    {
        var random = new Random();
        var newShuffledList = new List<string>();
        var listcCount = list.Count;
        for (int i = 0; i < listcCount; i++)
        {
            var randomElementInList = random.Next(0, list.Count);
            newShuffledList.Add(list[randomElementInList]);
            list.Remove(list[randomElementInList]);
        }
        return newShuffledList;
    }

    IEnumerator Lights()
    {
        while (true)
        {
            for (int i = 0; i<4; i++)
            {
                var a = (Btn)i;
                GameObject.Find(a.ToString()).GetComponent<SpriteRenderer>().color = colorList[i];
                yield return new WaitForSeconds(3f);
                GameObject.Find(a.ToString()).GetComponent<SpriteRenderer>().color = Color.black;
            }
            yield return new WaitForSeconds(3f);
        }
    }
}
