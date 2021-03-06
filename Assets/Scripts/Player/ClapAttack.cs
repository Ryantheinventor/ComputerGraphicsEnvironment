using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapAttack : Weapon
{
    public string animStateName = "Clap";
    private Animator animator;
    public LayerMask enemyLayer;
    public float radius = 2;
    public float damage = 10f;
    public float maxRange = 3;
    public GameObject vfxFab;
    public AudioClip fireSFX;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<PlayerMovement>().playerAnimator;
    }
    public override bool Attack(Vector3 target, Vector3 playerPos)
    {
        if (!animator.GetCurrentAnimatorStateInfo(1).IsName(animStateName) && Vector3.Distance(playerPos,target) < maxRange) 
        {
            animator.SetTrigger("Clap");
            audioSource.PlayOneShot(fireSFX);
            GameObject newVFX = Instantiate(vfxFab);
            newVFX.transform.position = target;
            newVFX.transform.forward = target - playerPos;

            Collider[] hits = Physics.OverlapSphere(target, radius, enemyLayer);
            foreach (Collider hit in hits) 
            {
                DestroyOnHealth enemyHealth = hit.GetComponent<DestroyOnHealth>();
                if (enemyHealth)
                {
                    enemyHealth.Health -= damage;
                }
                else 
                {
                    Debug.LogWarning("Object on enemy layer without health:" + hit.gameObject.name);
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}
