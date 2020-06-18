using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTriggerScript : MonoBehaviour
{
    public DamageAndHealthValues valueScipt; // accessing the DamageAndHealthValues script
    public PhaseManager phase;

    public int activatorVariable;

    public Material[] color;
    Renderer render;

    private void Start()
    {
        activatorVariable = 1;
         render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = color[0];
    }

    private void Update()
    {
        if(activatorVariable == 2)
        {
            render.sharedMaterial = color[1];
        }

        if(phase.phase == 2)
        {
            activatorVariable = Random.Range(1, 2);
        }

        if (phase.phase == 1)
        {
            activatorVariable = 1;
        }

        if (activatorVariable == 1)
        {
            render.sharedMaterial = color[0];
        }
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") // Making sure its the player leaving the collider
        {
            if (activatorVariable == 2)  // Making sure the tile is activated first
            {
                valueScipt.playerDamage++; // increasing the players damage
                activatorVariable = 1;
            }
            else
            {
                return;
            }
        }
    }
}
