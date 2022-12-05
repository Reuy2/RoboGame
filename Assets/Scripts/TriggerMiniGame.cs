using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMiniGame : MonoBehaviour
{
    public List<GameObject> WARNING_LIST;
    private static int COUNT_MINI_GAME;
    private static int COUNT_WARNINGS;
    private List<GameObject> Warnings;
    private Queue<GameObject> queueWarning;
    private Queue<GameObject> queueWarningSpawned;

    private void Start()
    {
        Warnings = new List<GameObject>(WARNING_LIST);
        queueWarning = new Queue<GameObject>(WARNING_LIST);
        queueWarningSpawned = new Queue<GameObject>();
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

    public int GetWarningLength()
    {
        return WARNING_LIST.Count;
    }

    public List<GameObject> GetWarningList()
    {
        return WARNING_LIST;
    }

    public GameObject SpawningWarning(int index)
    {
        return WARNING_LIST[index];
    }

    public void DespawningWarning()
    {
        queueWarning.Enqueue(queueWarningSpawned.Dequeue());
    }
}
