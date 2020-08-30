using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public float fractionScreen;
    float scale;
    float scaleXpos;
    float scaleYpos;

    public int playerMaxHealth;
    public int bossMaxHealth;

    float playerHealth;
    float bossHealth;

    public Image playerHealthBar;
    public Image bossHealthBar;

    public DamageAndHealthValues Values;

    void Start()
    {
        playerMaxHealth = 5;
        bossMaxHealth = 30;
        /*
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
        }*/

    }

    void Update()
    {
        playerHealth = Values.playerHealth;
        bossHealth = Values.bossHealth;

        playerHealthBar.fillAmount = playerHealth / playerMaxHealth;
        bossHealthBar.fillAmount = bossHealth / bossMaxHealth;

    }

}

