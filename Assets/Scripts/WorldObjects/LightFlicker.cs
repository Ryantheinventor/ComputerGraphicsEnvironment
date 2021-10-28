using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public float timeBetweenAttempt = 0.4f;
    private float curTime = 0;
    [Range(0,1)]
    public float chance = 0.5f;
    public GameObject light;
    private void Update() 
    {
        if(light)
        {
            curTime += Time.deltaTime;
            if(curTime>=timeBetweenAttempt)
            {
                int iChance = (int)(chance * 100);
                if(Random.RandomRange(0,100) <= iChance)
                {
                    light.SetActive(!light.activeSelf);
                }
                curTime = 0;
            }
        }
    }
}
