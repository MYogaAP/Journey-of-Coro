using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameTextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missionPanelText;

    void Update()
    {
        missionPanelText.text = string.Format("Get The Ducks {0}/{1}\n\nTime Left: {2}", 
            TrackItem.ItemScore, TrackItem.TotalItems, (int) TrackTimeLimit.TimeLeft);
    }
}
