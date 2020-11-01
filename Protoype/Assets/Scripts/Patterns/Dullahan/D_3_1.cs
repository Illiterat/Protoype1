﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_3_1 : PatternSuper
{
    // Instances of the attacks necisary for this pattern
    public Dullahead headScript;
    public GameObject head;

    public DullaStab stabScript;
    public DullaWhip whipScript;
    public DullaReverseWhip reverseWhipScript;
    public GameObject hazard;

    private GameObject[] tileRowTop;
    private GameObject[] tileRowMid;
    private GameObject[] tileRowBot;
    private GameObject[] tileColMid;
    private GameObject[] tileColR;
    private GameObject[] tileColL;


    // Start is called before the first frame update
    void Start()
    {
        phase = 3; //Set the phase for this attack

        //Set up for the head throw.
        headScript = gameObject.AddComponent<Dullahead>();
        headScript.projectile = this.head;

        //Set up for the spine stab
        /*if(gameObject.GetComponent(typeof(DullaStab)) == null)
        {*/
        stabScript = gameObject.AddComponent<DullaStab>();
        stabScript.hazard = this.hazard;
        /*}
        else
        {
            stabScript = gameObject.GetComponent(typeof(DullaStab)) as DullaStab;
        }*/

        //Set up for spine whip
        /*if(gameObject.GetComponent(typeof(DullaWhip)) == null)
        {*/
        whipScript = gameObject.AddComponent<DullaWhip>();
        whipScript.hazard = this.hazard;
        /*}
        else 
        {
            whipScript = gameObject.GetComponent(typeof(DullaWhip)) as DullaWhip;
        }*/

        reverseWhipScript = gameObject.AddComponent<DullaReverseWhip>();
        reverseWhipScript.hazard = this.hazard;


        //Set the rows and columns
        tileRowTop = new GameObject[] { tiles[0], tiles[1], tiles[2] };
        tileRowMid = new GameObject[] { tiles[3], tiles[4], tiles[5] };
        tileRowBot = new GameObject[] { tiles[6], tiles[7], tiles[8] };
        tileColMid = new GameObject[] { tiles[1], tiles[4], tiles[7] };
        tileColR = new GameObject[] { tiles[2], tiles[5], tiles[8] };
        tileColL = new GameObject[] { tiles[0], tiles[3], tiles[6] };
    }


    //The word "override" here lets me re-write what the function does
    public override IEnumerator Begin(GameObject emitter)
    {
        //----------UPDATE THIS
        headScript.fireSpeed = fireSpeed;
        //Reverse whip, middle, front. Head throw, middle col.
        yield return new WaitForSeconds(waitTime);
        reverseWhipScript.Launch(tileColL);
        yield return new WaitForSeconds(waitTime);
        whipScript.Launch(tileColMid);
        yield return new WaitForSeconds(waitTime);
        whipScript.Launch(tileColR);
        yield return new WaitForSeconds(waitTime);
        headScript.Launch(emitters[0]);
        yield return new WaitForSeconds(waitTime);
        whipScript.Launch(tileColMid);
    }
}
