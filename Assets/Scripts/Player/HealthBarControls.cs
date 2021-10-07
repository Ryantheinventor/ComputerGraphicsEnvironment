using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthBarControls : MonoBehaviour
{
    public float maxHealth;
    private float curHealth = 0;
    public float CurHealth 
    {
        get => curHealth; 
        set 
        {
            if (curHealth > value)
            {
                OnDamage.Invoke(curHealth - value);
            }
            else 
            {
                OnHeal.Invoke(value - curHealth);
            }
            curHealth = Mathf.Clamp(value, 0, maxHealth);

        }
    }
    public UnityEventFloat OnDamage { get; private set; } = new UnityEventFloat();
    public UnityEventFloat OnHeal { get; private set; } = new UnityEventFloat();

    private void Start() 
    {
        curHealth = maxHealth;
    }

}