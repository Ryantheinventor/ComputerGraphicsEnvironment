using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventFloat : UnityEvent<float> { }

public class UITestPlayer : MonoBehaviour
{
    public GameObject boxODeath;
    private float curWait = 4;
    private void Update() 
    {
        curWait -= Time.deltaTime;
        if (curWait < 0) 
        {
            GetComponent<HealthBarControls>().CurHealth += Random.Range(-50, 50);
            curWait = 1.2f;
        }
    }

}

