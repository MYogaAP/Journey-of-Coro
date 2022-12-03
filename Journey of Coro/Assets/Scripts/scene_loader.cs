using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene_loader : MonoBehaviour
{
    public Image loadingfill;
    private float wait;

    void Start()
    {
        wait = 0;
    }

    private void Update()
    {
        if (wait != -1)
        {
            wait += Time.deltaTime;
        }
        if (wait > 3)
        {
            wait = -1;
            StartCoroutine(Loading());
        }
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
