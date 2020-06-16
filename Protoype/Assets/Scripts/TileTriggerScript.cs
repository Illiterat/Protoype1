using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTriggerScript : MonoBehaviour
{
    public bool activated;  // tracking whether or not the tile is activated
    public DamageAndHealthValues valueScipt; // accessing the DamageAndHealthValues script

    private void Start()
    {
        activated = false; // setting value at the start
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player") // Making sure its the player leaving the collider
        {
            if (activated == true)  // Making sure the tile is activated first
            {
                valueScipt.playerDamage++; // increasing the players damage
                activated = false;  // resetting the tile
            }
            else
            {
                return;
            }
        }
    }
}
