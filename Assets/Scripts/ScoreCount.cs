using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    [SerializeField]
    float startScore = 100;

    [SerializeField]
    TMP_Text countdownText;
    public float StartScore
    {
        get { return startScore; }
        set { startScore = value; }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(startScore > 0)
        {
            startScore -= Time.deltaTime / 10;
            countdownText.text = Mathf.Ceil(startScore).ToString();
        }
    }
}
