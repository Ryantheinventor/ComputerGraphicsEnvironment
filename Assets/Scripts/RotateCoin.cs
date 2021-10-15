using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    public float anglesPerSecond = 90;
    public Vector3 angleAxisMultiplier;

    private void FixedUpdate()
    {
        transform.eulerAngles += angleAxisMultiplier * anglesPerSecond * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            FindObjectOfType<GameManager>().CurCoins++;
            Destroy(gameObject);
        }
    }


}
