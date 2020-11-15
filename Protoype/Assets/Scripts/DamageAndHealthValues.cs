using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DamageAndHealthValues : MonoBehaviour
{
    public AudioClip bossDamaged;
    public AudioSource source;

    public float playerDamage;  // player damage done to the boss (to be accessed by core movement script)
    public float playerHealth;  // player health value for health bar
    public float bossHealth;  // boss health value for health bar
    public float playerMaxHealth;
    public float bossMaxHealth;

    public Image playerHealthBar;
    public Image bossHealthBar;

    public PhaseManager Phase; // accessing the phase manager script

    void Start()
    {
        bossDamaged = Resources.Load<AudioClip>("Boss Takes Damage");
        GameObject Boss = GameObject.FindWithTag("Boss");
        source = Boss.GetComponent<AudioSource>();
        playerDamage = 0;  // starting values for variables
        playerMaxHealth = 5 + PlayerPrefs.GetFloat("health", 0);
        playerHealth = playerMaxHealth;
        bossMaxHealth = 30;
        bossHealth = bossMaxHealth;
    }

    void Update()
    {
        if(Phase.damage == true)
        {
            DamageBoss(); //Triggering the damage to the boss during the Damage phase
        }

        playerHealthBar.fillAmount = playerHealth / playerMaxHealth;
        bossHealthBar.fillAmount = bossHealth / bossMaxHealth;

        if(playerHealth <= 0)
        {
            playerHealth = 0;
        }

        if (bossHealth <= 0)
        {
            bossHealth = 0;
        }

        if (playerHealth == 0)
        {
            SceneManager.LoadScene(0); // loading the 'start' scene when the players's health goes below 0
        }

        if (bossHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Will move to next seen when boss dies
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
