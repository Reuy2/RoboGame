using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultySet : MonoBehaviour
{

    [SerializeField] Slider slider;
    public void Dificulty()
    {
        switch (slider.value)
        {
            case 0:
                DataHolder.Dificulty = 1.5f;
                return;
            case 1:
                DataHolder.Dificulty = 1f;
                return;
            case 2:
                DataHolder.Dificulty = 0.5f;
                return;
        }
    }
}
