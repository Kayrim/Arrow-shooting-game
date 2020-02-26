using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    float min = 0.1f;
    float max = 100f;
    public Image fill;
    // Start is called before the first frame update
    public void setSlider(float charge)
    {
        slider.value = charge;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void resetSlider()
    {
        slider.value = min;
    }

}
