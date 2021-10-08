using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapAttack : Weapon
{
    public string animStateName = "Clap";
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<PlayerMovement>().playerAnimator;
    }
    public override void Attack(Vector3 target)
    {
        if (!animator.GetCurrentAnimatorStateInfo(1).IsName(animStateName)) 
        {
            animator.SetTrigger("Clap");
        }
    }
}
