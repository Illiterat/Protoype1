using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBall : MonoBehaviour, AttackInterface
{
    public float firespeed {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*private void Launch(GameObject emitter)
    {
        GameObject projectileClone = Instantiate(projectile, emitter.transform.position, emitter.transform.rotation);
        projectileClone.GetComponent<Rigidbody2D>().velocity = -transform.right * fireSpeed;
    }*/

    public void Use()
    {

    }
}
