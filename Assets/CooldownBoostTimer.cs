using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBoostTimer : MonoBehaviour
{
    public Slider slider;

    public void SetScale(float Scale)
    {
        slider.value = Scale;
    }
}
