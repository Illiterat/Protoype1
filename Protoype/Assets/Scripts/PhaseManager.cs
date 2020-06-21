using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public int phase; // int for Phasemanagement

    public List<GameObject> tiles = new List<GameObject>();

    private bool isCoroutineExecuting = false;
    public bool damage;

    public int randomiser;


    public GameObject projectile;
    public int fireSpeed;

    public List<GameObject> emitters = new List<GameObject>();


    private void Start()
    {
        phase = 1; //starting phase
        damage = false;
    }

    void Update()
    {
        PhaseManagement();
    }

    void PhaseManagement() //Switch statement to navigate phases
    {
        switch (phase)
        {
            case 1:
                StartCoroutine(DodgePhase());
                break;

            case 2:
                StartCoroutine(AttackPhase());
                break;

            default:
                print("Wrong Int");
                break;
        }
    }

    private void Launch(GameObject emitter)
    {
        GameObject projectileClone = Instantiate(projectile, emitter.transform.position, emitter.transform.rotation);
        projectileClone.GetComponent<Rigidbody>().velocity = -transform.right * fireSpeed;
    }

    public IEnumerator DodgePhase()
    {
        if (isCoroutineExecuting)  //checking to see if another coroutine is running before moving on
            yield break;

        isCoroutineExecuting = true; //saying a coroutine is running

        foreach (GameObject tile in tiles)
        {
            TileTriggerScript tileScript;
            tileScript = tile.GetComponent<TileTriggerScript>();
            
            tileScript.render.sharedMaterial = tileScript.color[0];
            tileScript.activated = false;
        }

        //Example pattern
        
        Launch(emitters[0]);
        yield return new WaitForSeconds(1);
        Launch(emitters[1]);
        yield return new WaitForSeconds(1);
        Launch(emitters[2]);
        yield return new WaitForSeconds(1);
        Launch(emitters[1]);
         yield return new WaitForSeconds(1);
        Launch(emitters[0]);

        //End example pattern

        yield return new WaitForSeconds(6); //phase lasts 10 seconds (I deducted the amount used in the firing of projectiles)
        phase = 2; //moving to Attack Phase
        isCoroutineExecuting = false; //saying a coroutine is no longer running
    }

    public IEnumerator AttackPhase()
    {
        if (isCoroutineExecuting) //checking to see if another coroutine is running before moving on
            yield break;

        isCoroutineExecuting = true; //saying a coroutine is running

        foreach (GameObject tile in tiles )
        {
            TileTriggerScript tileScript;
            tileScript = tile.GetComponent<TileTriggerScript>();

            randomiser = Random.Range(1, 3);

            if(randomiser == 2)
            {
                tileScript.render.sharedMaterial = tileScript.color[1];
                tileScript.activated = true;
            }
            else if (randomiser == 1)
            {
                tileScript.render.sharedMaterial = tileScript.color[0];
                tileScript.activated = false;
            }
           

        }

        yield return new WaitForSeconds(5); //phase lasts 5 seconds
        damage = true;
        phase = 1; //moving to the damage phase
        isCoroutineExecuting = false; //saying a coroutine is no longer running
    }


}
