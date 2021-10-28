using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamFireAttack : Weapon
{
    public float damage = 1;
    public string animStateName = "Spam";
    public ParticleSystem ps;
    public Transform particleMount;
    private PlayerMovement playerMovement;
    private Animator animator;
    private Vector3 direction = Vector3.forward;
    private ParticleCollisionHandler pch;

    private void Start()
    {
        pch = ps.GetComponent<ParticleCollisionHandler>();
        pch.damage = damage;
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<PlayerMovement>().playerAnimator;
    }

    private void Update()
    {
        particleMount.transform.forward = direction;
    }

    public override bool Attack(Vector3 target, Vector3 playerPos)
    {
        if (!animator.GetCurrentAnimatorStateInfo(1).IsName(animStateName))
        {
            playerMovement.SetNewTargetLook(target);
            animator.SetTrigger("Spam");
            ps.Play();
            direction = (target - particleMount.position).normalized;
            particleMount.transform.forward = direction;
            return true;
        }
        else 
        {
            return false;
        }
    }
}
