using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneChanger : MonoBehaviour
{
    public static void ToLevelOne()
    {
        TrackGameState.ActiveState = "Story Scene";
        SceneManager.LoadScene("LoadingScene");
    }

    public static void ToLevelTwo()
    {
        TrackGameState.ActiveState = "Level 2";
        SceneManager.LoadScene("LoadingScene");
    }

    public static void ToLevelThree()
    {
        TrackGameState.ActiveState = "Level 3";
        SceneManager.LoadScene("LoadingScene");
    }

    public static void ToNextLevel()
    {
        string whatNext = "Start Menu";
        
        switch(TrackGameState.ActiveState)
        {
            case "Level 1": 
                whatNext = "Level 2";
                break;
            case "Level 2":
                whatNext = "Level 3";
                break;
            case "Level 3":
                whatNext = "Start Menu";
                break;
        } 

        TrackGameState.ActiveState = whatNext;
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
