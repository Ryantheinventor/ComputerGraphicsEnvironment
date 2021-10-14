using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaBar : MonoBehaviour
{
    public Mana manaTracker;
    public RectTransform bar;
    private float trueMana = 0;
    private float curValue = 0;
    private float barLengeth = 0;
    private float maxMana = 0;

    private void Start()
    {
        manaTracker.onManaChange.AddListener(UpdateBar);
        maxMana = manaTracker.maxMana;
        barLengeth = bar.sizeDelta.x;
    }


    public void UpdateBar(float manaValue) 
    {
        trueMana = manaValue;
    }

    private void Update()
    {
        curValue = Mathf.Lerp(curValue, trueMana, 15 * Time.deltaTime);
        SetSize(curValue, bar);
    }

    private void SetSize(float mana, RectTransform bar)
    {
        float curHealthRatio = mana / maxMana;

        float newWidth = barLengeth * curHealthRatio;

        bar.sizeDelta = new Vector2(newWidth, bar.sizeDelta.y);
    }

}
