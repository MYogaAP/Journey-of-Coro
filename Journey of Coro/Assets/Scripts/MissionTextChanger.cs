using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionTextChanger : MonoBehaviour
{
    private TextMeshProUGUI textObject;
    void Start()
    {
        textObject = gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textObject.text = string.Format("Get The Ducks {0}/{1}", TrackItem.ItemScore, TrackItem.TotalItems);
    }
}
