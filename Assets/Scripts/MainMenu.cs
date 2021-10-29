using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Contains all actions that can be made while on the main menu
public class MainMenu : MonoBehaviour
{
    public int sceneToLoadID = 1;
    public void OnPlay()
    {
        SceneManager.LoadScene(sceneToLoadID);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
