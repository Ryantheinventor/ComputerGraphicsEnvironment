using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIK : MonoBehaviour
{
    public Vector3 lookDirectionOffset = new Vector3();
    public Vector3 direction = new Vector3();
    private Animator anim;

    private void Start()
    {
        SetLookTarget(transform.forward);
        anim = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(1);
        anim.SetLookAtPosition(transform.position + direction + lookDirectionOffset);
    }

    public void SetLookTarget(Vector3 target) 
    {
        direction = (target - transform.position).normalized;
    }


}
