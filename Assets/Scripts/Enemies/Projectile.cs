using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 5;
    public float speed = 1;
    public Vector3 velocity = new Vector3();

    private void FixedUpdate()
    {
        transform.position += velocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealthBarControls>().CurHealth -= Random.Range(damage / 2f, damage);
        }
        Destroy(gameObject);
    }
}
