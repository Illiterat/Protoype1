using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageAndHealthValues : MonoBehaviour
{
    public AudioClip bossDamaged;
    public AudioSource source;

    public int playerDamage;  // player damage done to the boss (to be accessed by tile script)
    public int playerHealth;  // player health value for health bar
    public int bossHealth;  // boss health value for health bar

    public PhaseManager Phase; // accessing the phase manager script

    void Start()
    {
        bossDamaged = Resources.Load<AudioClip>("Boss Takes Damage");
        GameObject Boss = GameObject.FindWithTag("Boss");
        source = Boss.GetComponent<AudioSource>();
        playerDamage = 0;  // starting values for variables
        playerHealth = 5;
        bossHealth = 30;
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


        if (playerHealth == 0 || playerHealth <= 0)
        {
            SceneManager.LoadScene(0); // loading the 'start' scene when the boss's health goes below 0
        }

    }

    void DamageBoss()  // when triggered will reduce the boss health by the player damage
    {
        bossHealth -= playerDamage;
        source.PlayOneShot(bossDamaged);
        playerDamage = 0;  // resetting player damage
        Phase.damage = false; //Not damaging the boss a second time
        
    }

 }
