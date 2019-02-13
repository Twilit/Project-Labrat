using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {


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
}


