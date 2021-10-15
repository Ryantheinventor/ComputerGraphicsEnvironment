using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalCoins = 1;
    private int curCoins = 0;
    public int CurCoins 
    {
        get => curCoins;
        set
        { 
            curCoins = value;
            if (curCoins >= totalCoins) 
            {
                Debug.Log("You Win");
            }
        }
    }

    public HealthBarControls healthbar;

    private void Start()
    {
        healthbar.OnDamage.AddListener(OnPlayerDamage);
    }

    private void Update()
    {
        
    }

    public void OnPlayerDamage(float damage) 
    {
        if (healthbar.CurHealth <= 0) 
        {
            Debug.Log("Game Over");
        }
    }

}
