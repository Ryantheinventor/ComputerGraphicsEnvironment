using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TipDisplay : MonoBehaviour
{
    public LayerMask tipLayer;
    public GameObject tipPrefab;
    public Canvas mainCanvas;
    private GameObject curTipWindow = null;
    private Camera theCam;
    private Vector2 windowPosition = new Vector2(1,0);

    public static GameObject curUI = null;

    public static TipContainer curTip = null;


    private void Start() 
    {
        theCam = Camera.main;
    }


    private void Update() 
    {
        
        //display tip window
        if(curTip)
        {
            if(!curTipWindow)
            {
                curTipWindow = Instantiate(tipPrefab, mainCanvas.transform);
            }
            TipWindowController twc =  curTipWindow.GetComponent<TipWindowController>();
            twc.ForceUpdate();
            twc.SetScreenPos(Input.mousePosition, mainCanvas);
        }
        else
        {
            if(curTipWindow)
            {
                Destroy(curTipWindow);
                curTipWindow = null;//force it to be null
            }
        }

        if(GameManager.gamePaused)
        {
            //look for a tip to display
            if(!EventSystem.current.IsPointerOverGameObject())
            {
                
                Ray ray = theCam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hInfo, 100, tipLayer))
                {
                    Debug.Log(hInfo.collider.gameObject.name);
                    TipContainer tc = hInfo.collider.gameObject.GetComponent<TipContainer>();
                    if(tc)
                    {
                        curTip = tc;
                        Debug.Log($"Tip:{tc.tipName}... {tc.tipDesc}");
                    }
                    else
                    {
                        Debug.LogError($"No TipContainer found on object:({hInfo.collider.gameObject.name})");
                    }
                }
                else
                {
                    curTip = null;
                }            
            }
            else 
            {
                if(curUI)
                {
                    TipContainer tc = curUI.GetComponent<TipContainer>();
                    if(tc)
                    {
                        curTip = tc;
                    }
                    else
                    {
                        Debug.LogError($"No TipContainer found on object:({curUI.name})");
                    }
                }
                else
                {
                    curTip = null;
                }
            }
        }
        else
        {
            curTip = null;
        }

        
    }

}
