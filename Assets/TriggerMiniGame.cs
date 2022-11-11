using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMiniGame : MonoBehaviour
{
    public List<GameObject> WARNING_LIST;
    private static int COUNT_MINI_GAME;
    private static int COUNT_WARNINGS;
    private void Start()
    {
        //WARNING_LIST = new List<GameObject>(Resources.LoadAll<GameObject>("Warnings"));
        //print(WARNING_LIST);
    }
    public int CountWarnings()
    {
        return COUNT_WARNINGS;
    }

    public void CountWarnings(int count)
    {
        COUNT_WARNINGS += count;
    }

    public void CountGame(int count)
    {
        COUNT_MINI_GAME += count;
    }

    public int CountGame()
    {
        return COUNT_MINI_GAME;
    }

    public List<GameObject> GetWarningList()
    {
        return WARNING_LIST;
    }
}
