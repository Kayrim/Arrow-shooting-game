using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{

    public Slider slider;
    float min = 0.1f;
    float max = 100f;

    // Start is called before the first frame update
    public void setSlider(float charge)
    {
        slider.value = charge;
    }

    public void resetSlider()
    {
        slider.value = min;
    }

}
