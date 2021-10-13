using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHealth : MonoBehaviour
{
    public float maxHealth = 10;

    private float health = 0;

    public UnityEventFloat OnHealthChange { get; private set; } = new UnityEventFloat();

    public float Health 
    {
        get => health;
        set {
            if (value > 0)
            {
                health = value;
                OnHealthChange.Invoke(health);
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }

    private void Awake()
    {
        health = maxHealth;
    }


}
