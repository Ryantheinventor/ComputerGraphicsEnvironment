using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FButtonPause : MonoBehaviour
{
    private FancyButton fancyButton;
    private void Start() 
    {
        fancyButton = GetComponent<FancyButton>();    
    }

    private void Update() 
    {
        fancyButton.Enabled = !GameManager.gamePaused;    
    }
}
