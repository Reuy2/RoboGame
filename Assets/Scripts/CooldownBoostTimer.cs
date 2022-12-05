using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBoostTimer : MonoBehaviour
{
    public Slider slider;

    public void SetScale(float Scale)
    {
        if(slider.value + Scale > 100)
        {
            slider.value = 100;
        }
        else if (slider.value + Scale < 0)
        {
            slider.value = 0;
        }
        else
        {
            slider.value += Scale;
        }
    }

    public bool BoostCheck()
    {
        if(slider.value == 100)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
