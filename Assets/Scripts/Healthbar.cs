using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Healthbar : MonoBehaviour
{

    public HealthBarControls player;
    public TextMeshProUGUI text;
    public RectTransform slowBar;
    public RectTransform fastBar;
    private float maxHealth;
    private float trueHealth = 0;
    private float fastHealth = 0;
    private float slowHealth = 0;
    private float curWait = 1;
    private float hbLength = 0;



    private void Start()
    {
        player.OnDamage.AddListener(OnDamage);
        player.OnHeal.AddListener(OnHeal);
        maxHealth = player.maxHealth;
        trueHealth = maxHealth;
        slowHealth = maxHealth;
        fastHealth = maxHealth;
        hbLength = fastBar.sizeDelta.x;
        text.text = (int)trueHealth + "/" + (int)maxHealth;
    }

    //handles animation both over and under health bars to move to acurate positions smoothly
    private void Update()
    {


        fastHealth = Mathf.Lerp(fastHealth, trueHealth, 10 * Time.deltaTime);
        SetSize(fastHealth, fastBar);
        text.text = (int)fastHealth + "/" + (int)maxHealth;

        if (curWait <= 0)
        {
            
            slowHealth = Mathf.Lerp(slowHealth, trueHealth, 15 * Time.deltaTime);
            SetSize(slowHealth, slowBar);
        }
        else 
        {
            curWait -= Time.deltaTime;
        }

        if (Mathf.Abs(slowHealth - trueHealth) < 1)
        {
            slowHealth = trueHealth;
        }
        if (Mathf.Abs(fastHealth - trueHealth) < 1)
        {
            fastHealth = trueHealth;
        }
    }


    public void OnDamage(float damage)
    {
        curWait = 1;
        trueHealth -= damage;
        if (trueHealth < 0)
        {
            trueHealth = 0;
        }
    }

    public void OnHeal(float healing)
    {
        curWait = 0;
        trueHealth += healing;
        if (trueHealth >= maxHealth)
        {
            trueHealth = maxHealth;
        }
    }

    //sets the bar to a scale based off the health value passed to it
    private void SetSize(float health, RectTransform bar) 
    {
        float curHealthRatio = health / maxHealth;

        float newWidth = hbLength * curHealthRatio;
        
        bar.sizeDelta = new Vector2(newWidth, bar.sizeDelta.y);
    }

}
