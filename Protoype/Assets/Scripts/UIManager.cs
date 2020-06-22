using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject playerHB;
    public GameObject bossHB;
    public GameObject playerBack;
    public GameObject bossBack;
    
    public float fractionScreen;
    float scale;
    float scaleXpos;
    float scaleYpos;

    int playerMaxHealth = 10;
    int bossMaxHealth = 10;

    float playerHealth;
    float bossHealth;

    public DamageAndHealthValues Values;

    void Start()
    {
        scale = Screen.width / fractionScreen;
        scaleXpos = Screen.width / 5;
        scaleYpos = Screen.height - (Screen.height / 8);

        if (scale <= 1)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(scale, scale, 0);
        }

        playerBack.transform.localScale = new Vector3(scale, 1, 0);
        bossBack.transform.localScale = new Vector3(scale, 1, 0);

        playerBack.transform.position = new Vector3(scaleXpos, scaleYpos, 0);
        bossBack.transform.position = new Vector3((Screen.width - scaleXpos), scaleYpos, 0);
    }

    void Update()
    {
        if(Values.playerHealth <= 0)
        {
            playerHealth = 0; //This is so the bar doesn't increase when the health goes into negitives. 
        }
        else
        {
            playerHealth = (scale / playerMaxHealth) * Values.playerHealth;
        }

        bossHealth = (scale / bossMaxHealth) * Values.bossHealth;

        playerHB.transform.localScale = new Vector3(playerHealth, 1, 0);
        bossHB.transform.localScale = new Vector3(bossHealth, 1, 0);

        playerHB.transform.position = new Vector3(scaleXpos - ((playerMaxHealth - Values.playerHealth) * scale * 7), scaleYpos, 0);
        bossHB.transform.position = new Vector3((Screen.width - scaleXpos + (bossMaxHealth - Values.bossHealth) * scale * 7), scaleYpos, 0);
    }

}

