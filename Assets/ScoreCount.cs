using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    [SerializeField]
    float StartScore = 100;

    [SerializeField]
    TMP_Text countdownText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartScore -= Time.deltaTime;
        countdownText.text = Mathf.Ceil(StartScore).ToString();
    }
}
