using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollide : MonoBehaviour
{
    [SerializeField] private TriggerMiniGame TriggerController;
    [SerializeField] private GameObject asteroidDust;
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
<<<<<<< Updated upstream
            
=======
>>>>>>> Stashed changes
            if (Warning_List.Count - TriggerController.CountWarnings() > 0)
            {
                int RandomWarning = Random.Range(0, Warning_List.Count);
                Debug.Log(Warning_List.Count);
                Instantiate(Warning_List[RandomWarning], transform);

                // ��� ��� ������� ����� � ������ ���������. ���� ������� � ��������� �������� ������, ����� ���� � �� �� ��������� �� ���� ���.
            }
            else
            {
                //��� �������� �������� �� ���������� ��������������� ���������� �����������
            }
        }
<<<<<<< Updated upstream
=======
        Debug.Log("Hit detected");

>>>>>>> Stashed changes
        Destroy(collision.gameObject);

        GameObject asteriodDestroy = Instantiate(asteroidDust);
        asteriodDestroy.transform.position = collision.transform.position;
        Animation anim = asteroidDust.GetComponent<Animation>();
        Destroy(asteriodDestroy, anim.clip.length);
    }
}
