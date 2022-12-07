using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameTextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missionPanelText;

    void Update()
    {
        missionPanelText.text = string.Format("Get The Ducks {0}/{1}\nTime Limit is {2} Minutes\nDon't Let the Human\nKnow Your Presence!", 
            TrackItem.ItemScore, TrackItem.TotalItems, (int)TrackTimeLimit.TimeMax/60);
    }
}
