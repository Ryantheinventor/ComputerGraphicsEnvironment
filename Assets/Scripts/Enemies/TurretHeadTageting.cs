using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHeadTageting : MonoBehaviour
{
    public Rigidbody target;
    private Rigidbody myRB;
    [HideInInspector]
    public Vector3 targetDirection = new Vector3();

    private void Start() 
    {
        myRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        targetDirection = target.position - myRB.position;
        myRB.rotation = Quaternion.LookRotation(new Vector3(targetDirection.x,0,targetDirection.z), Vector3.up);
    }


}
