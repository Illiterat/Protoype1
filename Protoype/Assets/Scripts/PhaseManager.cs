using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    public int phase; // int for Phasemanagement

    private bool isCoroutineExecuting = false;
    public bool damage;

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
        //enter conditions for dodge phase here


        yield return new WaitForSeconds(10); //phase lasts 10 seconds
        phase = 2; //moving to Attack Phase
        isCoroutineExecuting = false; //saying a coroutine is no longer running
    }

    public IEnumerator AttackPhase()
    {
        if (isCoroutineExecuting) //checking to see if another coroutine is running before moving on
            yield break;

        isCoroutineExecuting = true; //saying a coroutine is running


        yield return new WaitForSeconds(5); //phase lasts 5 seconds
        damage = true;
        phase = 1; //moving to the damage phase
        isCoroutineExecuting = false; //saying a coroutine is no longer running
    }


}
