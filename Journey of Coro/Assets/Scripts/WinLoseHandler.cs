using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoseHandler : MonoBehaviour
{
    /*[SerializeField] Text ItemText;*/
    [SerializeField] int itemsTaken = 0;

    // Start is called before the first frame update
    void Start()
    {
        TrackItem.ItemScore = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        itemsTaken = TrackItem.ItemScore;

        if (itemsTaken == TrackItem.TotalItems)
        {
            SceneManager.LoadScene("GameWinScene");
        }

        if(TrackEnemyAwareness.Awareness >= 100)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
