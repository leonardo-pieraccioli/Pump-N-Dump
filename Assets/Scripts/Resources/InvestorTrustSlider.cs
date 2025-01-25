using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvestorTrustSlider : MonoBehaviour
{
    public static Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;
    }

    public static void UpdateValue(float gain){
        slider.value += gain;
    }
}
