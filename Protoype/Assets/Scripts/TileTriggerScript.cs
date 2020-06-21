using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTriggerScript : MonoBehaviour
{

    public bool activated; // a few local variables for tracking on individual tiles in the array

    public Material[] color; 
    public Renderer render;

    private void Start()
    {
        activated = false;
         render = GetComponent<Renderer>(); //setting starting values for the variables
        render.enabled = true;
        render.sharedMaterial = color[0];
    }
   
}
