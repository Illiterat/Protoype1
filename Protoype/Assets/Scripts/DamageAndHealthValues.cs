﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageAndHealthValues : MonoBehaviour
{
    public int playerDamage;  // player damage done to the boss (to be accessed by tile script)
    public int playerHealth;  // player health value for health bar
    public int bossHealth;  // boss health value for health bar

    public PhaseManager Phase; // accessing the phase manager script

    void Start()
    {
        playerDamage = 0;  // starting values for variables
        playerHealth = 10;
        bossHealth = 10;
    }

    void Update()
    {
        if(Phase.damage == true)
        {
            DamageBoss(); //Triggering the damage to the boss during the Damage phase
        }
        else
        {
            return;
        }

        if (bossHealth == 0 || bossHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loading the 'win' scene when the boss's health goes below 0
        }

    }

    void DamageBoss()  // when triggered will reduce the boss health by the player damage
    {
        bossHealth -= playerDamage;
        playerDamage = 0;  // resetting player damage
        Phase.damage = false; //Not damaging the boss a second time
    }
}