using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Damages a DestroyOnHealh object after a particle collision with it
public class ParticleCollisionHandler : MonoBehaviour
{
    [HideInInspector]
    public float damage = 1;
    private void OnParticleCollision(GameObject other)
    {
        DestroyOnHealth doh = other.GetComponent<DestroyOnHealth>();
        if (doh)
        {
            doh.Health -= damage;
        }
    }
}
