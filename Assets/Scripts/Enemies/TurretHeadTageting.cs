﻿using System.Collections;
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
        Vector3 targetDirection = target.position - myRB.position;
        myRB.rotation = Quaternion.LookRotation(new Vector3(targetDirection.x,0,targetDirection.z), Vector3.up);
    }


}
