using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSpawn : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private int indexOfWarning;
    [SerializeField] private GameObject _warningMiniGame;
    private TriggerMiniGame _triggerController;
    private void Awake()
    {
        _triggerController = GameObject.Find("TriggerController").GetComponent<TriggerMiniGame>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && Input.GetKey(KeyCode.E))
        {
            _warningMiniGame.SetActive(true);
        }
    }

    private void OnEnable()
    {
        _triggerController.CountWarnings(1);
        print(_triggerController.CountWarnings());
    }
    private void OnDisable()
    {
        _triggerController.CountWarnings(-1);
    }
}
