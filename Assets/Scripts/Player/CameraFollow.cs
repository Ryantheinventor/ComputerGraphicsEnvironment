using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 15, -14);


    private void FixedUpdate()
    {
        transform.position = target.position + offset; 
    }

}
