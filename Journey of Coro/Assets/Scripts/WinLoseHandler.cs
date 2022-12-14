using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoseHandler : MonoBehaviour
{
    /*[SerializeField] Text ItemText;*/
    [SerializeField] int itemsTaken = 0;
    [SerializeField] float timeLimitInMinutes = 5;

    // Start is called before the first frame update
    void Start()
    {
        TrackItem.ItemScore = 0;
        TrackEnemyAwareness.Awareness = 0;
        TrackTimeLimit.TimeLeft = timeLimitInMinutes * 60;
        TrackTimeLimit.TimeMax = timeLimitInMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        TrackTimeLimit.TimeLeft -= Time.deltaTime;
        itemsTaken = TrackItem.ItemScore;

        if (itemsTaken == TrackItem.TotalItems)
        {
            SceneManager.LoadScene("GameWinScene");
        }

        if(TrackEnemyAwareness.Awareness >= 100 || TrackTimeLimit.TimeLeft <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
