using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaParticleCollision : MonoBehaviour
{
    public float manaPerParticle = 1;

    Mana manaStorage;

    void OnParticleCollision(GameObject other) {
        if(other.CompareTag("Player"))
        {
            if(!manaStorage)
            {
                manaStorage = other.GetComponent<Mana>();
            }
            manaStorage.CurMana += manaPerParticle;
        }
    }
}
