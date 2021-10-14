using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnEvent : MonoBehaviour
{

    public Vector3 destPos = new Vector3(0, 0, 0);
    public float lerpSpeed = 1;
    private bool move = false;
    // Update is called once per frame
    void Update()
    {
        if (move) 
        {
            transform.position = Vector3.Lerp(transform.position, destPos, lerpSpeed * Time.deltaTime);
        }
    }

    public void StartMoving() 
    {
        move = true;
    }

}
