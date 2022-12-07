using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient timerGradient;
    [SerializeField] private Image fill;
    private int currentTime;

    private void Start()
    {
        currentTime = (int) TrackTimeLimit.TimeLeft;
        slider.maxValue = 1;
        slider.minValue = 0;
        slider.value = currentTime;
        fill.color = timerGradient.Evaluate(0);
        timerText.text = string.Format("Time:\n{0}", currentTime);
    }

    void Update()
    {
        if(slider.maxValue != TrackTimeLimit.TimeMax)
        {
            slider.maxValue = TrackTimeLimit.TimeMax;
        }
        if (currentTime != (int)TrackTimeLimit.TimeLeft)
        {
            currentTime = (int)TrackTimeLimit.TimeLeft;
            slider.value = currentTime;
            fill.color = timerGradient.Evaluate(slider.normalizedValue);
            timerText.text = string.Format("Time:\n{0}", currentTime);
        }
    }
}
