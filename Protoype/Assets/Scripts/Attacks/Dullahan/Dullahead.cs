using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dullahead : MonoBehaviour
{
    public float fireSpeed {get; set;}
    public GameObject projectile;

    // Start is called before the first frame update
    

    public void Launch(GameObject emitter)
    {
        
        GameObject projectileClone = Instantiate(projectile, emitter.transform.position, emitter.transform.rotation);
        projectileClone.GetComponent<DullaProjectile>().enabled = true;
        projectileClone.GetComponent<Rigidbody2D>().velocity = -transform.right * fireSpeed;
        //Debug.Log("Speed in ball: " + fireSpeed);
    }
}
