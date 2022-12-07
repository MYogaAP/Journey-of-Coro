using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AwarenessBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI awarenessText;
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient awarenessGradient;
    [SerializeField] private Image fill;
    private int currentAwareness;

    private void Start()
    {
        currentAwareness = TrackEnemyAwareness.Awareness;
        slider.maxValue = 100;
        slider.minValue = 0;
        slider.value = currentAwareness;
        fill.color = awarenessGradient.Evaluate(0);
        awarenessText.text = string.Format("{0}%", currentAwareness);
    }

    void Update()
    {
        if (currentAwareness != TrackEnemyAwareness.Awareness)
        {
            currentAwareness = TrackEnemyAwareness.Awareness;
            slider.value = currentAwareness;
            fill.color = awarenessGradient.Evaluate(slider.normalizedValue);
            awarenessText.text = string.Format("{0}%", currentAwareness);
        }
    }
}
