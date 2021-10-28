using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardManaDisplay : MonoBehaviour
{
    public MeshRenderer[] meshes;
    public Mana manaStorage;
    private Material usedMat;
    private Color color;

    private void Start() 
    {
        if(meshes.Length > 0)
        {
            usedMat = meshes[0].material;
            color = usedMat.GetColor("_EmissionColor");
        }
        foreach(MeshRenderer m in meshes)
        {
            m.material = usedMat;
        }
    }

    private void Update() 
    {
        usedMat.SetColor("_EmissionColor", color * (manaStorage.CurMana / manaStorage.maxMana));
    }

    void OnDestroy() 
    {
        Destroy(usedMat);
    }

}
