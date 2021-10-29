using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player health container that controlls a HealthBar object
public class HealthBarControls : MonoBehaviour
{
    public float maxHealth;
    private float curHealth = 0;
    public float CurHealth 
    {
        get => curHealth; 
        set 
        {
            float tempHealth = curHealth;
            curHealth = Mathf.Clamp(value, 0, maxHealth);
            if (tempHealth > value)
            {
                OnDamage.Invoke(tempHealth - value);
            }
            else 
            {
                OnHeal.Invoke(value - tempHealth);
            }
            

        }
    }
    public UnityEventFloat OnDamage { get; private set; } = new UnityEventFloat();
    public UnityEventFloat OnHeal { get; private set; } = new UnityEventFloat();

    private void Start() 
    {
        curHealth = maxHealth;
    }

}