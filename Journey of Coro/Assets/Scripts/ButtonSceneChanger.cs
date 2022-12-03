using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChanger : MonoBehaviour
{
    public static void ToLevelOne()
    {
        TrackGameState.ActiveState = "Level 1";
        SceneManager.LoadScene("LoadingScene");
    }

    public static void ToMenu()
    {
        TrackGameState.ActiveState = "Start Menu";
        SceneManager.LoadScene("LoadingScene");
    }

    public static void PlayAgain()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}
