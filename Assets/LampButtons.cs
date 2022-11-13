using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using System;

public class LampButtons : MonoBehaviour
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
        trigger = GameObject.Find("TriggerController").GetComponent<TriggerMiniGame>();
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
        if (correct == 4)
        {
            Debug.Log("Done");
            Done();
            return;
        }
        if (correct > 4)
        {
            return;
        }
        var a = (keyboard_to_color)Enum.Parse(typeof(keyboard_to_color), buttonList[correct]);
        if (Input.GetKeyDown((KeyCode)a))
        {
            correct += 1;
            return;
        }
        else if (Input.anyKeyDown)
        {
            correct = 0;
            Debug.Log("Fission mailed");
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
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 4; i++)
            {
                var a = (Btn)Enum.Parse(typeof(Btn), buttonList[i]);
                GameObject.Find(a.ToString()).GetComponent<SpriteRenderer>().color = colorList[(int)a];
                yield return new WaitForSeconds(1f);
                GameObject.Find(a.ToString()).GetComponent<SpriteRenderer>().color = Color.black;
            }
        }
    }


    void Done()
    {
        player.MovementAllowChangeToTrue();
        if (trigger.CountGame() >= 1)
        {
            trigger.CountGame(-1);
        }
        Destroy(GameObject.FindGameObjectWithTag("MiniGame"));
        Debug.Log(GameObject.Find("LampButtonsWarn(Clone)")); // Вот тут косяк какой-то, хз. Не получается удалить варнинг, (макс)ща пофикшу
        Destroy(GameObject.Find("LampButtonsWarn(Clone)"));
    }
}
