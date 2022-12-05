using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private TextMeshProUGUI pressNext;
    private int imageNum;
    private float wait;

    void Start()
    {
        wait = 0;
        imageNum = 0;
        gameObject.GetComponent<Image>().sprite = sprite[imageNum];
    }

    private void Update()
    {
        wait += Time.deltaTime;

        if (Input.anyKey && wait > 2 && imageNum >= (sprite.Length-1))
        {
            TrackGameState.ActiveState = "Level 1";
            SceneManager.LoadScene("LoadingScene");
        }

        if (Input.anyKey && wait > 2 && imageNum < (sprite.Length - 1))
        {
            gameObject.GetComponent<AudioSource>().Play();
            wait = 0;
            imageNum++;
            gameObject.GetComponent<Image>().sprite = sprite[imageNum];
        } 
    }
}
