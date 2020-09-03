using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBall : MonoBehaviour, AttackInterface
{
    public float fireSpeed {get; set;}
    public GameObject projectile;

    /*public OrangeBall(GameObject projectile, float firespeed)
    {
        this.projectile = projectile;
        this.fireSpeed = fireSpeed;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Launch(GameObject emitter)
    {
        
        GameObject projectileClone = Instantiate(projectile, emitter.transform.position, emitter.transform.rotation);
        projectileClone.GetComponent<Rigidbody2D>().velocity = -transform.right * fireSpeed;
        //Debug.Log("Speed in ball: " + fireSpeed);
    }

}
