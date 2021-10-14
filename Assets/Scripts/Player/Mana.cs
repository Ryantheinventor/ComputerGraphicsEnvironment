using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float maxMana = 100;
    public float rechargeSpeed = 10;
    public bool startWithMax = true;
    private float curMana = 0;
    public float CurMana 
    {
        get => curMana;
        set 
        {
            curMana = value;
            onManaChange.Invoke(curMana);
        }
    }
    public UnityEventFloat onManaChange { get; private set; } = new UnityEventFloat();
    

    private void Start()
    {
        if (startWithMax) 
        {
            CurMana = maxMana;
        }
        onManaChange.Invoke(CurMana);
    }

    private void Update()
    {
        if (CurMana < maxMana)
        {
            CurMana += rechargeSpeed * Time.deltaTime;
        }
        if (CurMana > maxMana) 
        {
            CurMana = maxMana;
        }
    }

}
