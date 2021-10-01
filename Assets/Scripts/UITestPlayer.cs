using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventFloat : UnityEvent<float> { }

public class UITestPlayer : MonoBehaviour
{
    public GameObject boxODeath;
    public float maxHealth;
    public UnityEventFloat OnHealthChanged { get; private set; } = new UnityEventFloat();


    private void OnCollisionEnter(Collision collision)
    {
        OnHealthChanged.Invoke(Random.Range(5,20));
    }
}
