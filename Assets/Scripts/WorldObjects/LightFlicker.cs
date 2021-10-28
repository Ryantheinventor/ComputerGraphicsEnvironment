using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float timeBetweenAttempt = 0.4f;
    private float curTime = 0;
    [Range(0,1)]
    public float chance = 0.5f;
    public GameObject fLight;
    private void Update() 
    {
        if(fLight)
        {
            curTime += Time.deltaTime;
            if(curTime>=timeBetweenAttempt)
            {
                int iChance = (int)(chance * 100);
                if(Random.Range(0,100) <= iChance)
                {
                    fLight.SetActive(!fLight.activeSelf);
                }
                curTime = 0;
            }
        }
    }
}
