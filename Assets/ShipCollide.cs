using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollide : MonoBehaviour
{
    [SerializeField] private TriggerMiniGame TriggerController;
<<<<<<< Updated upstream
    private List<GameObject> Warning_List;
    // Start is called before the first frame update

    private void Start()
    {
        Warning_List = TriggerController.GetWarningList();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
=======
    [SerializeField] private Transform _shipUncoveredTransform;
    private List<GameObject> _warningList;
    private int countWarningAfterLimit = 0;

    private void Start()
    {
        _warningList = TriggerController.GetWarningList();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
>>>>>>> Stashed changes
        if (collision.gameObject.tag == "Player")
            return;
        if (collision.gameObject.tag == "MiniGamePlayer")
            return;
        if (collision.gameObject.tag == "Asteroid")
        {
<<<<<<< Updated upstream
            if(Warning_List.Count - TriggerController.CountWarnings() > 0)
            {
                int RandomWarning = Random.Range(0, Warning_List.Count - 1 - TriggerController.CountWarnings());
                Instantiate(Warning_List[RandomWarning], transform);
            }
            else
=======

            foreach(GameObject warning in _warningList)
>>>>>>> Stashed changes
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
