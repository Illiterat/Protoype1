using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTriggerScript : MonoBehaviour
{

    public bool activated;

    public Material[] color;
    public Renderer render;

    private void Start()
    {
        activated = false;
         render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = color[0];
    }
   
}
