using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//destroys an object if a bool is set to true
public class DestroyOnBool : MonoBehaviour
{
    public bool destroy = false;

    private void Update()
    {
        if (destroy) { Destroy(gameObject); }
    }
}
