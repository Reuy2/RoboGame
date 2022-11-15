using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollide : MonoBehaviour
{
    [SerializeField] private TriggerMiniGame TriggerController;
    [SerializeField] private Transform _shipUncoveredTransform;
    private List<GameObject> Warning_List;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Warning_List = TriggerController.GetWarningList();
        if (collision.gameObject.tag == "Player")
            return;
        if(collision.gameObject.tag == "Asteroid")
        {
            
            if (Warning_List.Count  > 0)
            {
                int RandomWarning = Random.Range(0, Warning_List.Count-1);
                Debug.Log(Warning_List.Count);
                Debug.Log(RandomWarning);
                Instantiate(Warning_List[RandomWarning], _shipUncoveredTransform);
                TriggerController.SpawningWarning(RandomWarning);

                // Вот тут большой(не такой он уж и большой(макс)) косяк с листом варнингов. Надо удалять и добавлять элементы списка, иначе одно и то же спавнится по куче раз.
            }
            else
            {
                //Тут вставить проигрыш по достижении многочисленного количества повреждений
            }
        }
        Destroy(collision.gameObject);
    }
}
