using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollide : MonoBehaviour
{
    [SerializeField] private TriggerMiniGame TriggerController;
    private List<GameObject> Warning_List;
    // Start is called before the first frame update

    private void Start()
    {
        Warning_List = TriggerController.GetWarningList();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            return;
        if(collision.gameObject.tag == "Asteroid")
        {
            if(Warning_List.Count - TriggerController.CountWarnings() > 0)
            {
                int RandomWarning = Random.Range(0, Warning_List.Count - 1 - TriggerController.CountWarnings());
                Instantiate(Warning_List[RandomWarning], transform);
            }
            else
            {
                //Тут вставить проигрыш по достижении многочисленного количества повреждений
            }
        }
        Debug.Log("Hit detected");
        Destroy(collision.gameObject);
    }
}
