using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseManager : MonoBehaviour
{
    public int phase; // int for Phasemanagement

    public List<GameObject> tiles = new List<GameObject>(); //List of tiles for activation

    private bool isCoroutineExecuting = false;
    public bool damage;

    public int randomiser; //Variable for picking a random bool outcome for tiles.

    public GameObject projectile;
    public GameObject speedSlider; //Slider to change projectile speed at runtime.
    [Range(1.0f, 50.0f)]
    public float fireSpeed;
    private float timeModifier; //Modifier used to change times between launching projectiles
    public float launchTimeModifier; //Amount of projectiles that are shot before the first one reaches the middle of the players tiles

    public List<GameObject> emitters = new List<GameObject>();


    private void Start()
    {
        phase = 1; //starting phase
        damage = false;
        speedSlider.GetComponent<Slider>().value = fireSpeed;
    }

    void Update()
    {
        fireSpeed = speedSlider.GetComponent<Slider>().value;
        timeModifier = 14/fireSpeed; //Time it takes for a projectile to reach the centre of the players grid
        PhaseManagement(); // calling switch statement
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
        yield return new WaitForSeconds(timeModifier/launchTimeModifier);
        Launch(emitters[1]);
        yield return new WaitForSeconds(timeModifier/launchTimeModifier);
        Launch(emitters[2]);
        yield return new WaitForSeconds(timeModifier/launchTimeModifier);
        Launch(emitters[1]);
         yield return new WaitForSeconds(timeModifier/launchTimeModifier);
        Launch(emitters[0]);
        yield return new WaitForSeconds(timeModifier/launchTimeModifier);
        Launch(emitters[0]);
        yield return new WaitForSeconds(timeModifier/launchTimeModifier);
        Launch(emitters[1]);
        yield return new WaitForSeconds(timeModifier/launchTimeModifier);
        Launch(emitters[2]);
        yield return new WaitForSeconds(timeModifier/launchTimeModifier);
        Launch(emitters[1]);
        yield return new WaitForSeconds(timeModifier/launchTimeModifier);
        Launch(emitters[0]);

        //End example pattern

        yield return new WaitForSeconds(1); //phase lasts 10 seconds (I deducted the amount used in the firing of projectiles)
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
            TileTriggerScript tileScript; //grabbing individual tile scripts
            tileScript = tile.GetComponent<TileTriggerScript>();

            randomiser = Random.Range(1, 3); //picking a random value for activated or inactivated

            if(randomiser == 2)
            {
                tileScript.render.sharedMaterial = tileScript.color[1]; //activating the tile
                tileScript.activated = true;
            }
            else if (randomiser == 1)
            {
                tileScript.render.sharedMaterial = tileScript.color[0]; //not activating the tile
                tileScript.activated = false;
            }
        }

        yield return new WaitForSeconds(2); //phase lasts 2 seconds
        damage = true;
        phase = 1; //moving to the damage phase
        isCoroutineExecuting = false; //saying a coroutine is no longer running
    }


}
