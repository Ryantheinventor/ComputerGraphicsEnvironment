using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHeadTageting : MonoBehaviour
{
    public Rigidbody target;
    private Rigidbody myRB;


    private void Start() 
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        myRB.rotation = Quaternion.LookRotation(target.position - myRB.position, Vector3.up);
    }


}
