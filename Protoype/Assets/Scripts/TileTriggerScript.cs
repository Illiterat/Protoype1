using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTriggerScript : MonoBehaviour
{
    public AudioClip deactivation;
    public AudioSource source;

    public bool activated; // a few local variables for tracking on individual tiles in the array

    public Sprite[] color; 
    public SpriteRenderer render;

    private void Start()
    {
        deactivation = Resources.Load<AudioClip>("Player Stepping on Activated Platforms");
        source = GetComponent<AudioSource>();
        activated = false;
        render = GetComponent<SpriteRenderer>(); //setting starting values for the variables
        render.enabled = true;
        render.sprite = color[0];
    }
   
   

}
