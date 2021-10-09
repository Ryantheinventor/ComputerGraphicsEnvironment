using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAttack : Weapon
{
    public string animStateName = "Push";
    private Animator animator;
    public GameObject pushVFXFab;

    private void Start()
    {
        animator = GetComponent<PlayerMovement>().playerAnimator;
    }

    public override void Attack(Vector3 target, Vector3 playerPos)
    {
        if (!animator.GetCurrentAnimatorStateInfo(1).IsName(animStateName))
        {
            animator.SetTrigger("Push");
            GameObject newVFX = Instantiate(pushVFXFab);
            newVFX.transform.position = playerPos;
            newVFX.transform.forward = target - playerPos;
        }
    }
}
