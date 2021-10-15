using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
            CoinText.text = CurCoins + "/" + totalCoins;
            if (curCoins >= totalCoins) 
            {
                Debug.Log("You Win");
            }
        }
    }

    public HealthBarControls healthbar;
    public TextMeshProUGUI CoinText;

    private void Start()
    {
        healthbar.OnDamage.AddListener(OnPlayerDamage);
        CoinText.text = CurCoins + "/" + totalCoins;
    }

    public void OnPlayerDamage(float damage) 
    {
        if (healthbar.CurHealth <= 0) 
        {
            Debug.Log("Game Over");
        }
    }

}
