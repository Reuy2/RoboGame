using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] Slider slider;
    public void SoundLoud()
    {
        DataHolder.Sound = slider.value;
    }
}
