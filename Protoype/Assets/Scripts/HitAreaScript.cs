using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAreaScript : MonoBehaviour
{
    public AudioClip playerDamaged;
    public AudioSource source;
    public DamageAndHealthValues healthManager;
    private bool hazardous = false;

    // Start is called before the first frame update
    void Start()
    {
        playerDamaged = Resources.Load<AudioClip>("Player Taking Damage");
        GameObject player = GameObject.FindWithTag("Player");
        source = player.GetComponent<AudioSource>();
        Invoke("MakeHazardous", 1);
    }

    private void MakeHazardous()
    {
        hazardous = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(hazardous)
        {
            Debug.Log("Collides");
            if (other.tag == "Player")
            {
                healthManager.playerHealth--;
                source.PlayOneShot(playerDamaged);
                Destroy(gameObject);
            }
        }
        
    }
}
