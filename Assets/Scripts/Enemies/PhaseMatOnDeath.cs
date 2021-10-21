using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseMatOnDeath : DestroyOnHealth
{

    private bool phaseing = false;
    public float phaseSpeed = 1f;
    private Material myMat;
    public SkinnedMeshRenderer meshRenderer;
    protected override void OnNoHealth()
    {
        phaseing = true;
    }

    private void Start()
    {
        myMat = meshRenderer.material;
    }

    private void Update()
    {
        if (phaseing) 
        {
            myMat.SetFloat("PhaseAlpha", myMat.GetFloat("PhaseAlpha") - phaseSpeed * Time.deltaTime);
            if (myMat.GetFloat("PhaseAlpha") <= 0) 
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        Destroy(myMat);
    }

}
