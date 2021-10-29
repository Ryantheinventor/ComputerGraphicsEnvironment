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
            //ends the game when all coins are collected
            if (curCoins >= totalCoins && !gameOver) 
            {
                gameOver = true;
                Instantiate(winCanvas);
                DisablePlayer();
                Debug.Log("You Win");
            }
        }
    }

    public HealthBarControls healthbar;
    public TextMeshProUGUI CoinText;

    public GameObject loseCanvas;
    public GameObject winCanvas;
    private bool gameOver = false;
    private void Start()
    {
        healthbar.OnDamage.AddListener(OnPlayerDamage);
        CoinText.text = CurCoins + "/" + totalCoins;
    }

    //checks if the game should end when the player takes damage
    public void OnPlayerDamage(float damage) 
    {
        if (healthbar.CurHealth <= 0 && !gameOver) 
        {
            gameOver = true;
            Instantiate(loseCanvas);
            DisablePlayer();
            Debug.Log("Game Over");
        }
    }

    //disables player movement for when the game is finished
    private void DisablePlayer()
    {
        PlayerMovement pm = FindObjectOfType<PlayerMovement>();
        pm.playerAnimator.SetFloat("Speed",0);
        pm.playerAnimator.SetFloat("RelativeX",0);
        pm.playerAnimator.SetFloat("RelativeY",0);
        pm.GetComponent<PlayerAttack>().enabled = false;
        pm.enabled = false;
    }
}
