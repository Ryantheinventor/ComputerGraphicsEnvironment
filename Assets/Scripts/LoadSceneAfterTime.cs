using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAfterTime : MonoBehaviour
{
    public int sceneID = 0;
    public float waitTime = 5;

    private void Update()
    {
        waitTime -= Time.deltaTime;
        if(waitTime<=0)
        {
            SceneManager.LoadScene(sceneID);
        }
    }
}
