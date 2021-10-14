using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[Serializable]
public class LeverSwitchEvent : UnityEvent { }

public class Lever : MonoBehaviour
{

    public LeverSwitchEvent onSwtich;
    public GameObject switchJoint;

    private bool hasSwitched = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.GetComponent<PushProjectile>() && !hasSwitched) 
        {
            switchJoint.transform.eulerAngles *= -1;
            onSwtich.Invoke();
            hasSwitched = true;
        }
    }
}
