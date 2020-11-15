using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhaseManager : MonoBehaviour
{
    public AudioClip projectileLaunch;
    public AudioSource source;

    public int phase; // int for Phasemanagement
    public int bossPhase; // int for bossphase
    public int randomiser; //Variable for picking a random bool outcome for tiles.
    public int time;

    private bool isCoroutineExecuting = false;
    private bool isSecondaryCoroutineExecuting = false;
    public bool damage;

    public float fireSpeed;
    private float timeModifier; //Modifier used to change times between launching projectiles
    public float launchTimeModifier; //Amount of projectiles that are shot before the first one reaches the middle of the players tiles

    public List<GameObject> emitters = new List<GameObject>();
    public List<GameObject> tiles = new List<GameObject>(); //List of tiles for activation
    List<PatternSuper> patternsPhase1 = new List<PatternSuper>();
    List<PatternSuper> patternsPhase2 = new List<PatternSuper>();
    List<PatternSuper> patternsPhase3 = new List<PatternSuper>();

    public DamageAndHealthValues health;

    private void Start()
    {
        projectileLaunch = Resources.Load<AudioClip>("Projectile Launch");
        phase = 1; //starting phase
        bossPhase = 1; //starting phase
        damage = false;

        PatternSuper[] patterns = GetComponents<PatternSuper>();
        

        foreach (PatternSuper p in patterns)
        {
            p.emitters = this.emitters;
            p.tiles = this.tiles;
            p.fireSpeed = fireSpeed;
            switch(p.phase)
            {
                case 1:
                {
                    this.patternsPhase1.Add(p);
                    break;
                }
                case 2:
                {
                    this.patternsPhase2.Add(p);
                    break;
                }
                case 3:
                {
                    this.patternsPhase3.Add(p);
                    break;
                }
                default:
                {
                    Debug.Log("The phase was not correctly assigned, it shows: " + p.phase);
                    break;
                }
            }
            
        }

        SetTime();
    }

    void Update()
    {
        fireSpeed = PlayerPrefs.GetFloat("speed", 0);
        timeModifier = 14/fireSpeed; //Time it takes for a projectile to reach the centre of the players grid
        
        //Set the current waittime and firespeed of each pattern
        foreach (PatternSuper p in patternsPhase1)
        {
            p.waitTime = timeModifier / launchTimeModifier;
            p.fireSpeed = fireSpeed;
        }
        foreach (PatternSuper p in patternsPhase2)
        {
            p.waitTime = timeModifier / launchTimeModifier;
            p.fireSpeed = fireSpeed;
        }
        foreach (PatternSuper p in patternsPhase3)
        {
            p.waitTime = timeModifier / launchTimeModifier;
            p.fireSpeed = fireSpeed;
        }

        PhaseManagement(); // calling switch statement
    }

    void SetTime()
    {
        time = PlayerPrefs.GetInt("time", 0);
        Debug.Log("Time set to: " + time);
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

            tileScript.render.sprite = tileScript.color[0];
            tileScript.activated = false;
        }

        BossPhaseManagement(); //calling Boss phase attack stuff

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
            TileTriggerScript tileScript; //grabbing individual tile scripts
            tileScript = tile.GetComponent<TileTriggerScript>();

            randomiser = Random.Range(1, 3); //picking a random value for activated or inactivated

            if(randomiser == 2)
            {
                tileScript.render.sprite = tileScript.color[1]; //activating the tile
                tileScript.activated = true;
            }
            else if (randomiser == 1)
            {
                tileScript.render.sprite = tileScript.color[0]; //not activating the tile
                tileScript.activated = false;
            }
        }

        yield return new WaitForSeconds(time); //phase lasts 2 seconds
        damage = true;
        phase = 1; //moving to the damage phase
        isCoroutineExecuting = false; //saying a coroutine is no longer running
    }

    void BossPhaseManagement() //Switch statement to navigate phases
    {
        switch (bossPhase)
        {
            case 1:
                StartCoroutine(Phase1());
                break;

            case 2:
                StartCoroutine(Phase2());
                break;
            case 3:
                StartCoroutine(Phase3());
                break;

            default:
                print("Wrong Int");
                break;
        }
    }

    public IEnumerator Phase1()
    {
        if (isSecondaryCoroutineExecuting) //checking to see if another coroutine is running before moving on
            yield break;

        isSecondaryCoroutineExecuting = true; //saying a coroutine is running

        if (health.bossHealth <= 20)
        {
            bossPhase = 2;
        }

        int randomInt = Random.Range(0, patternsPhase1.Count); // Create a random int to represent the chosen pattern
        yield return StartCoroutine(patternsPhase1[randomInt].Begin(emitters[0])); // Run that pattern
        
        isSecondaryCoroutineExecuting = false; //saying a coroutine is no longer running
    }

    public IEnumerator Phase2()
    {
        if (isSecondaryCoroutineExecuting) //checking to see if another coroutine is running before moving on
            yield break;

        if (health.bossHealth <= 10)
        {
            bossPhase = 3;
        }

        isSecondaryCoroutineExecuting = true; //saying a coroutine is running

        int randomInt = Random.Range(0, patternsPhase2.Count); // Create a random int to represent the chosen pattern
        yield return StartCoroutine(patternsPhase2[randomInt].Begin(emitters[1])); // Run that pattern

        isSecondaryCoroutineExecuting = false; //saying a coroutine is no longer running
    }

    public IEnumerator Phase3()
    {
        if (isSecondaryCoroutineExecuting) //checking to see if another coroutine is running before moving on
            yield break;

        isSecondaryCoroutineExecuting = true; //saying a coroutine is running

        int randomInt = Random.Range(0, patternsPhase3.Count); // Create a random int to represent the chosen pattern
        yield return StartCoroutine(patternsPhase3[randomInt].Begin(emitters[1])); // Run that pattern

        isSecondaryCoroutineExecuting = false; //saying a coroutine is no longer running
    }
}
