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

        yield return new WaitForSeconds(10); //phase lasts 10 seconds
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
