using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
