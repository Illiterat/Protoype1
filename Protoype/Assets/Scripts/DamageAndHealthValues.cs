using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageAndHealthValues : MonoBehaviour
{
    public int playerDamage;  // player damage done to the boss (to be accessed by tile script)
    public int playerHealth;  // player health value for health bar
    public int bossHealth;  // boss health value for health bar

    public PhaseManager Phase; // accessing the phase manager script

    void Start()
    {
        playerDamage = 1;  // starting values for variables
        playerHealth = 10;
        bossHealth = 10;
    }

    void Update()
    {
        if(Phase.damage == true)
        {
            DamageBoss(); //Triggering the damage to the boss during the Damage phase
            Phase.damage = false; //Not damaging the boss a second time
        }
        else
        {
            return;
        }
    }

    void DamageBoss()  // when triggered will reduce the boss health by the player damage
    {
        bossHealth -= playerDamage;
        playerDamage = 1;  // resetting player damage
    }
}
