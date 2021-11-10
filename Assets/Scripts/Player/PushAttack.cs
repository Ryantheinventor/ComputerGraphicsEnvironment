using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAttack : Weapon
{
    public string animStateName = "Push";
    private Animator animator;
    public GameObject pushVFXFab;
    public AudioClip fireSFX;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<PlayerMovement>().playerAnimator;
    }

    public override bool Attack(Vector3 target, Vector3 playerPos)
    {
        if (!animator.GetCurrentAnimatorStateInfo(1).IsName(animStateName))
        {
            audioSource.PlayOneShot(fireSFX);
            animator.SetTrigger("Push");
            GameObject newVFX = Instantiate(pushVFXFab);
            newVFX.transform.position = playerPos;
            newVFX.transform.forward = target - playerPos;
            return true;
        }
        else
        {
            return false;
        }
    }
}
