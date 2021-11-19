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
        StartCoroutine(LoadAsyncScene(sceneToLoadID));
    }

    IEnumerator LoadAsyncScene(int id)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(id);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            Debug.Log(asyncLoad.progress);
            yield return null;
        }
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
