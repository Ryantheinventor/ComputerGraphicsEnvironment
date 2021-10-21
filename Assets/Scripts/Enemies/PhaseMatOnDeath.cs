using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseMatOnDeath : DestroyOnHealth
{

    private bool phasing = false;
    public float phaseSpeed = 1f;
    private List<Material> myMats = new List<Material>();
    public MeshRenderer[] meshRenderers;
    public SkinnedMeshRenderer[] skinnedMeshRenderers;
    protected override void OnNoHealth()
    {
        phasing = true;
    }

    private void Start()
    {
        foreach (SkinnedMeshRenderer smr in skinnedMeshRenderers)
        {
            myMats.Add(smr.material);
        }
        foreach (MeshRenderer smr in meshRenderers)
        {
            myMats.Add(smr.material);
        }

    }

    private void Update()
    {
        if (phasing) 
        {
            foreach (Material m in myMats) 
            {
                m.SetFloat("PhaseAlpha", m.GetFloat("PhaseAlpha") - phaseSpeed * Time.deltaTime);
            }
            if (myMats[0].GetFloat("PhaseAlpha") <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        foreach (Material m in myMats)
        {
            Destroy(m);
        }
    }

}
