using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Instatiates an object OnGo()
public class Instantiator : MonoBehaviour
{
    public GameObject fab;
    public void OnGo() 
    {
        Instantiate(fab);
    }
}
