using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient timerGradient;
    [SerializeField] private Image fill;
    private float currentTime;

    private void Start()
    {
        currentTime = TrackTimeLimit.DashTime;
        slider.maxValue = 5;
        slider.minValue = 0;
        slider.value = currentTime;
        fill.color = timerGradient.Evaluate(0);
    }

    void Update()
    {
        if (currentTime != TrackTimeLimit.DashTime)
        {
            currentTime = TrackTimeLimit.DashTime;
            slider.value = currentTime;
            fill.color = timerGradient.Evaluate(slider.normalizedValue);
        }
    }
}
