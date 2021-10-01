using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[Serializable]
public class FancyClickEvent : UnityEvent { }

public class FancyButton : MonoBehaviour
{
    [Header("Color")]
    public Color selectedTint = new Color(1, 1, 1, 1);
    public Color pressedTint = new Color(1, 1, 1, 1);
    public float colorChangeSpeed = 1f;
    private Color startTint;
    private Image myImage;

    [Header("Movement")]
    public Vector2 selectedPixelDelta = new Vector2(5, 5);
    public Vector2 pressedPixelDelta = new Vector2(-5, -5);
    public float sizeChangeSpeed = 1f;
    private Vector2 defaultSize;
    private RectTransform myRect;
    private bool mouseIsOver = false;
    private bool mouseIsDown = false;

    [Header("Button Events")]
    public FancyClickEvent onHold;

    public FancyClickEvent onClick;

    private void Start()
    {
        myImage = GetComponent<Image>();
        startTint = myImage.color;
        myRect = transform as RectTransform;
        defaultSize = myRect.sizeDelta;




        EventTrigger et = GetComponent<EventTrigger>();
        if (!et) 
        {
            et = gameObject.AddComponent<EventTrigger>();
        }
        EventTrigger.Entry entry0 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerEnter };
        entry0.callback.AddListener(new UnityAction<BaseEventData>(MouseEnter));
        et.triggers.Add(entry0);

        EventTrigger.Entry entry1 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerExit };
        entry1.callback.AddListener(new UnityAction<BaseEventData>(MouseExit));
        et.triggers.Add(entry1);

        EventTrigger.Entry entry2 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerDown };
        entry2.callback.AddListener(new UnityAction<BaseEventData>(MouseDown));
        et.triggers.Add(entry2);

        EventTrigger.Entry entry3 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerUp };
        entry3.callback.AddListener(new UnityAction<BaseEventData>(MouseUp));
        et.triggers.Add(entry3);
    }

    private void Update()
    {
        if (mouseIsDown)
        {
            myImage.color = Color.Lerp(myImage.color, pressedTint, colorChangeSpeed * Time.deltaTime);
            myRect.sizeDelta = Vector2.Lerp(myRect.sizeDelta, defaultSize + pressedPixelDelta, sizeChangeSpeed * Time.deltaTime);
            onHold.Invoke();
        }
        else if (mouseIsOver)
        {
            myImage.color = Color.Lerp(myImage.color, selectedTint, colorChangeSpeed * Time.deltaTime);
            myRect.sizeDelta = Vector2.Lerp(myRect.sizeDelta, defaultSize + selectedPixelDelta, sizeChangeSpeed * Time.deltaTime);
        }
        else 
        {
            myImage.color = Color.Lerp(myImage.color, startTint, colorChangeSpeed * Time.deltaTime);
            myRect.sizeDelta = Vector2.Lerp(myRect.sizeDelta, defaultSize, sizeChangeSpeed * Time.deltaTime);
        }
    }



    public void MouseEnter(BaseEventData bed)
    {
        mouseIsOver = true;
    }

    public void MouseExit(BaseEventData bed)
    { 
        mouseIsOver = false;
    }

    public void MouseDown(BaseEventData bed)
    {
        mouseIsDown = true;
    }

    public void MouseUp(BaseEventData bed)
    {
        mouseIsDown = false;
        onClick.Invoke();
    }

}
