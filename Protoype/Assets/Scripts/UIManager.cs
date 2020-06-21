using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject playerHB;
    public GameObject enemyHB;
    public GameObject playerBack;
    public GameObject enemyBack;

    public float fractionScreen;
    float scale;

    public DamageAndHealthValues Values;

    void Start()
    {
        scale = Screen.width / fractionScreen;

        if (scale <= 1)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(scale, scale, 0);
        }

        playerBack.transform.localScale = new Vector3(scale, 1, 0);
        enemyBack.transform.localScale = new Vector3(scale, 1, 0);
    }

    void Update()
    {
        float playerHealth = (scale / 10) * Values.playerHealth;
        float enemyHealth = (scale / 10) * Values.bossHealth;

        playerHB.transform.localScale = new Vector3(playerHealth, 1, 0);
        enemyHB.transform.localScale = new Vector3(enemyHealth, 1, 0);

    }

}

