using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollide : MonoBehaviour
{
    [SerializeField] private TriggerMiniGame TriggerController;
    [SerializeField] private Transform _shipUncoveredTransform;
    private List<GameObject> _warningList;
    private int countWarningAfterLimit = 0;

    private void Start()
    {
        _warningList = TriggerController.GetWarningList();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            return;
        if (collision.gameObject.tag == "MiniGamePlayer")
            return;
        if (collision.gameObject.tag == "Asteroid")
        {
            foreach(GameObject warning in _warningList)
            {
                if(warning.activeSelf == false)
                {
                    warning.SetActive(true);
                    break;
                }

            }
            //тут добавить предупреждение о проигрыше
            //и тут же добавить проигрыш от большого количества варнингов
            
        }
        Debug.Log("Hit detected");
        Destroy(collision.gameObject);
    }
}
