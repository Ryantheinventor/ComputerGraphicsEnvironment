using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TipWindowController : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;

    public RectTransform windowRect;

    private void Update() 
    {
        if(TipDisplay.curTip)
        {
            titleText.text = TipDisplay.curTip.tipName;
            descText.text = TipDisplay.curTip.tipDesc;
        }
        Debug.Log(windowRect.rect.width);
    }

    public void SetScreenPos(Vector2 newPos, Canvas canvas)
    {
        transform.position = newPos;
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().rect.size;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 windowSize = windowRect.rect.size;
        float widthRatio = screenSize.x / canvasSize.x;

        windowSize *= widthRatio;

        if(newPos.x + windowSize.x >= screenSize.x)
        {
            if(newPos.y < windowSize.y)
            {
                //left up
                windowRect.pivot = new Vector2(1,0);
                windowRect.anchoredPosition = new Vector2(0,0);
            }
            else
            {
                //left down
                windowRect.pivot = new Vector2(1,1);
                windowRect.anchoredPosition = new Vector2(0,0);
            }
        }
        else
        {
            if(newPos.y < windowSize.y)
            {
                //right up
                windowRect.pivot = new Vector2(0,0);
                windowRect.anchoredPosition = new Vector2(0,0);
            }
            else
            {
                //right down
                windowRect.pivot = new Vector2(0,1);
                windowRect.anchoredPosition = new Vector2(0,0);
            }
        }
    }

    public void ForceUpdate()
    {
        Update();
    }
}
