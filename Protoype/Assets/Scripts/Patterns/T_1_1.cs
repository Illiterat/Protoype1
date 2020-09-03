using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_1_1 : PatternSuper
{
    // Instances of the attacks necisary for this pattern
    public OrangeBall orangeAttack;
    public GameObject ball;


    // Start is called before the first frame update
    void Start()
    {
        phase = 1; //Set the phase for this attack
        
        orangeAttack = gameObject.AddComponent<OrangeBall>();
        //ball firespeed
        
        orangeAttack.projectile = this.ball;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //The word "override" here lets me re-write what the function does
    public override IEnumerator Begin(GameObject emitter)
    {
        //Debug.Log("Wait time inside pattern" + waitTime);
        //yield return new WaitForSeconds(waitTime);
        //Testing for when it's fully implemented

        orangeAttack.fireSpeed = fireSpeed;
        
        orangeAttack.Launch(emitters[0]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[1]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[2]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[1]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[0]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[0]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[1]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[2]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[1]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[0]);
    }

}
