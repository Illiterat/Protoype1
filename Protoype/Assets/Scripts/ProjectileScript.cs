using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public AudioClip playerDamaged;
    public AudioSource source;
    public DamageAndHealthValues healthManager;

    // Start is called before the first frame update
    void Start()
    {
        playerDamaged = Resources.Load<AudioClip>("Player Taking Damage");
        GameObject player = GameObject.FindWithTag("Player");
        source = player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<Rigidbody>().velocity);
    }

    private void OnTriggerEnter2D (Collider2D other)
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
