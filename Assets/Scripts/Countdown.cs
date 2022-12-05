using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    float currentTime = 0;
    float startingTime = 120;

    [SerializeField]
    TMP_Text countdownText;
    [SerializeField]
    Image countdownProgressBar;

    float minutes;
    float seconds;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        CountdownTimer();
        CountdownProgressBar();
    }

    private void CountdownTimer()
    {
        minutes = currentTime / 60;
        seconds = currentTime % 60;

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = Mathf.Round(minutes).ToString() + " : " + Mathf.Round(seconds).ToString();

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    private void CountdownProgressBar()
    {
        countdownProgressBar.fillAmount = currentTime / startingTime;
    }
}
