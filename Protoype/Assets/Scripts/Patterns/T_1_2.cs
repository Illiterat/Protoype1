using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_1_2 : PatternSuper
{
    // Instances of the attacks necisary for this pattern
    public OrangeBall orangeAttack;
    public GameObject ball;

    void Awake()
    {
        phase = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        orangeAttack = gameObject.AddComponent<OrangeBall>();
        //ball firespeed
        
        orangeAttack.projectile = this.ball;
        phase = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerator Begin()
    {
        Debug.Log("Wait time inside pattern" + waitTime);
        yield return new WaitForSeconds(waitTime);
        //Testing for when it's fully implemented

        orangeAttack.fireSpeed = fireSpeed;
        
        orangeAttack.Launch(emitters[0]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[0]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[0]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[1]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[1]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[1]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[2]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[2]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[2]);
        yield return new WaitForSeconds(waitTime);
        orangeAttack.Launch(emitters[2]);
    }
}
