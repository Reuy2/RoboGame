using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] float _time = 10;
    private float _estimatedTime = 0;
    void Update()
    {
        _estimatedTime += Time.deltaTime;

        if(_time < _estimatedTime)
        {
            SceneManager.LoadScene(0);
        }
    }
}
