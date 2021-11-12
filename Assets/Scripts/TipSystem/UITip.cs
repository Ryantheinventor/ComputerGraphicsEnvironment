using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UITip : MonoBehaviour
{
    
    private void Start() 
    {
        EventTrigger et = GetComponent<EventTrigger>();
        if (!et) 
        {
            //add event trigger if it is not found
            et = gameObject.AddComponent<EventTrigger>();
        }

        //add mouse events to the event trigger
        EventTrigger.Entry entry0 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerEnter };
        entry0.callback.AddListener(new UnityAction<BaseEventData>(MouseEnter));
        et.triggers.Add(entry0);

        EventTrigger.Entry entry1 = new EventTrigger.Entry() { eventID = EventTriggerType.PointerExit };
        entry1.callback.AddListener(new UnityAction<BaseEventData>(MouseExit));
        et.triggers.Add(entry1);
    }

    public void MouseEnter(BaseEventData bed) 
    {
        TipDisplay.curUI = gameObject;
    }

    public void MouseExit(BaseEventData bed) 
    {
        if(TipDisplay.curUI == gameObject)
        {
            TipDisplay.curUI = null;
        }
    }

}
