using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DullaProjectile : MonoBehaviour
{
    public AudioClip playerDamaged;
    public AudioSource source;
    public DamageAndHealthValues healthManager;

    public CoreMovement moveScript;

    private SpriteRenderer headRenderer;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerDamaged = Resources.Load<AudioClip>("Player Taking Damage");
        player = GameObject.FindWithTag("Player");
        source = player.GetComponent<AudioSource>();
        headRenderer = gameObject.GetComponent<SpriteRenderer>();
        Vector3 pos = transform.position;
        pos.y = player.transform.position.y;
        transform.position = pos;
    }

    

    private void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Collides");
        if (other.tag == "Player")
        {
            healthManager.playerHealth--;
            source.PlayOneShot(playerDamaged);
            
        }
        if (other.tag == "DullahanWall")
        {
            Destroy(gameObject);
        }
        if (other.tag == "ReboundWall")
        {
            Vector3 pos = transform.position;
            pos.y = player.transform.position.y;
            transform.position = pos;
            headRenderer.flipX = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity * -1;
        }
    }
}
