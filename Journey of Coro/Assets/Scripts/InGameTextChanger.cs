using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameTextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missionPanelText;

    void Update()
    {
        missionPanelText.text = string.Format("Get The Ducks {0}/{1}\nEnemy Awareness {2}%\nTime Left: {3}", 
            TrackItem.ItemScore, TrackItem.TotalItems,TrackEnemyAwareness.Awareness, (int) TrackTimeLimit.TimeLeft);
    }
}
