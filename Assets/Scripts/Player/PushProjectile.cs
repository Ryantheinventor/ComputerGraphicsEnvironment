using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushProjectile : MonoBehaviour
{
    public float damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Enemy")) 
        {
            other.GetComponent<DestroyOnHealth>().Health -= damage;
        }
    }
}
