using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSpawn : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    private TriggerMiniGame _triggerController;
    private void Awake()
    {
        transform.Translate(x, y, 0);
        _triggerController = GameObject.Find("TriggerController").GetComponent<TriggerMiniGame>();
        _triggerController.CountWarnings(1);
        print(_triggerController.CountWarnings());
    }

    private void OnDestroy()
    {
        _triggerController.CountWarnings(-1);
    }
}
