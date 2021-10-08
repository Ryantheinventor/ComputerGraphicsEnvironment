using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttack : Weapon
{
    public string animStateName = "Wave";
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<PlayerMovement>().playerAnimator;
    }
    public override void Attack(Vector3 target, Vector3 playerPos)
    {
        if (!animator.GetCurrentAnimatorStateInfo(1).IsName(animStateName))
        {
            animator.SetTrigger("Wave");
        }
    }
}
