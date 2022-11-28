using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShipCollide : MonoBehaviour
{
    [SerializeField] private TriggerMiniGame TriggerController;
    [SerializeField] private Transform _shipUncoveredTransform;
    [SerializeField] GameObject Text;
    private List<GameObject> _warningList;
    private int countWarningAfterLimit = 0;

    private int deathState = 0;

    private void Start()
    {
        _warningList = TriggerController.GetWarningList();
    }

    private void FixedUpdate()
    {
        foreach (GameObject warning in _warningList)
        {
            if (warning.activeSelf == false)
            {
                deathState = 0;
                return;
            }

        }

        if (deathState == 2)
        {
            SceneManager.LoadScene(1);

        }
    }

    private void Update()
    {
        if(deathState == 1)
        {
            Text.SetActive(true);
            return;
        }
        Text.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            return;
        if (collision.gameObject.tag == "MiniGamePlayer")
            return;

        Destroy(collision.gameObject);

        if (collision.gameObject.tag == "Asteroid")
        {
            foreach(GameObject warning in _warningList)
            {
                if(warning.activeSelf == false)
                {
                    deathState = 0;
                    warning.SetActive(true);
                    return;
                }

            }
            deathState += 1;

            //тут добавить предупреждение о проигрыше
            //и тут же добавить проигрыш от большого количества варнингов
            
        }
    }
}
