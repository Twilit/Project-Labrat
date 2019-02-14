using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public void loadMain()
    {
        print("start");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        print("loaded");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }



}


