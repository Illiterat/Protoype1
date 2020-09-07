using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_1_1 : PatternSuper
{
    // Instances of the attacks necisary for this pattern
    public Dullahead headScript;
    public GameObject head;


    // Start is called before the first frame update
    void Start()
    {
        phase = 1; //Set the phase for this attack
        
        headScript = gameObject.AddComponent<Dullahead>();
        //ball firespeed
        
        headScript.projectile = this.head;
        
    }


    //The word "override" here lets me re-write what the function does
    public override IEnumerator Begin(GameObject emitter)
    {
        //Debug.Log("Wait time inside pattern" + waitTime);
        //yield return new WaitForSeconds(waitTime);
        //Testing for when it's fully implemented

        headScript.fireSpeed = fireSpeed;
        
        yield return new WaitForSeconds(waitTime);
        headScript.Launch(emitters[0]);
        
       
    }
}
