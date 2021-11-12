using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMover : MonoBehaviour
{
    public bool targetOnPause = true;
    public Vector2 targetPos = new Vector2(0,0);
    public float lerpT = 5f;
    private Vector2 startingPos = new Vector2();
    private Vector2 curTargetPos = new Vector2(0,0);

    RectTransform rt;

    // Start is called before the first frame update
    void Start()
    {
        rt =  GetComponent<RectTransform>();
        startingPos = rt.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gamePaused == targetOnPause)
        {
            curTargetPos = targetPos;
        }
        else
        {
            curTargetPos = startingPos;
        }

        rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, curTargetPos, Time.unscaledDeltaTime * lerpT);

    }

}
