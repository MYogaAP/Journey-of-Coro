using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene_loader : MonoBehaviour
{
     public Image loadingfill;

    void Start()
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(TrackGameState.ActiveState);

        while (!loading.isDone)
        {
            loadingfill.fillAmount = loading.progress/0.9f;
            print(loading.progress);
            yield return null;
        }
    } 
}
