using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMiniGame : MonoBehaviour
{
    [SerializeField] private GameObject _miniGame;

    private static int COUNT_MINI_GAME;

    private static int COUNT_WARNINGS;

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
}
