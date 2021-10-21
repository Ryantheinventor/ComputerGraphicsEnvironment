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
            health = value;
            OnHealthChange.Invoke(health);
            if (value <= 0)
            {
                OnNoHealth();
            }
        }
    }

    private void Awake()
    {
        health = maxHealth;
    }

    protected virtual void OnNoHealth() 
    {
        Destroy(gameObject);
    }

}
