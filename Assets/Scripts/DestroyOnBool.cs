using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBool : MonoBehaviour
{
    public bool destroy = false;

    private void Update()
    {
        if (destroy) { Destroy(gameObject); }
    }
}
