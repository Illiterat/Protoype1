using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreMovement : MonoBehaviour
{
    //Dictionary for storing keybinds
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public int spacesY = 3; //Size of array Columns
    public int spacesX = 3; //Size of array Rows

    public DamageAndHealthValues valueScipt; // accessing the DamageAndHealthValues script
    public TileTriggerScript currentSpace;
    public float movementSpeed;

    public List<GameObject> spacesInput = new List<GameObject>(); //For taking the objects in from the inspector
    public GameObject[,] spaces = new GameObject[3, 3]; //The array of possitions
    public GameObject playerDestination;
    public GameObject player;

    int currentX; //Current X position in array.
    int currentY; //Current Y position in array.

    // Start is called before the first frame update
    void Start()
    {
        //Just incase we put in the wrong numbers
        //Checks if the array is the correct size to contain our game objects
        if (spacesInput.Count != spacesY * spacesX)
        {
            //Error message incase it doesn't have the right amount of space.
            Debug.Log("Array size does not match the number of input elements");
        }
        else
        {
            //Assign the game objects to the spaces in the 2D array.

            int listElement = 0; //Variable to track the current list element.

            //Loop through the list and assign elements to the correct position in array.
            //i controls column itteration, j controls row itteration.
            for (int i = 0; i < spacesY; i++)
            {
                for (int j = 0; j < spacesX; j++)
                {
                    //Debug.Log(i + " " + j); //Used for debuging array asigning.
                    spaces[j, i] = spacesInput[listElement];
                    listElement++; //Move on to the next element of the list.
                }
            }

            //Set the starting point for the player. (at the moment coordinate 1,1)
            currentX = 1;
            currentY = 1;
            playerDestination.transform.position = spaces[currentX, currentY].transform.position;
        }

        //Adds our stored keys to the dictionary
        //This will need to be done again if the player changes keybinds during game
        keys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));

    }

    // Update is called once per frame
    void Update()
    {
        CheckForActivation();
        player.transform.position = Vector3.Lerp(player.transform.position, playerDestination.transform.position, movementSpeed * Time.deltaTime);

        if (Input.GetKeyDown(keys["Right"])) //Right movement
        {
            //Check if space to move to exists
            if (currentX + 1 < spacesX)
            {
                currentX++; //Update variable representing it's position
                //Move the player
                playerDestination.transform.position = spaces[currentX, currentY].transform.position;
                //Debug.Log(currentX + "," + currentY); //Uncomment to display position as you move
            }
        }
        else if (Input.GetKeyDown(keys["Left"])) //Left movement
        {
            if (currentX - 1 >= 0)
            {
                currentX--;
                playerDestination.transform.position = spaces[currentX, currentY].transform.position;
                //Debug.Log(currentX + "," + currentY); //Uncomment to display position as you move
            }
        }
        else if (Input.GetKeyDown(keys["Up"])) //Up movement
        {
            if (currentY - 1 >= 0)
            {
                currentY--;
                playerDestination.transform.position = spaces[currentX, currentY].transform.position;
                //Debug.Log(currentX + "," + currentY); //Uncomment to display position as you move
            }
        }
        else if (Input.GetKeyDown(keys["Down"])) //Down movement
        {
            if (currentY + 1 < spacesY)
            {
                currentY++;
                playerDestination.transform.position = spaces[currentX, currentY].transform.position;
                //Debug.Log(currentX + "," + currentY); //Uncomment to display position as you move
            }
        }
    }
    //Mwahahahahah I am saying something
    void CheckForActivation()
    {
       currentSpace = spaces[currentX, currentY].GetComponent<TileTriggerScript>();
    
       if(currentSpace.activated == true)
        {
            valueScipt.playerDamage++; // increasing the players damage
            currentSpace.render.sharedMaterial = currentSpace.color[0];
            currentSpace.activated = false;
        }
    }

}
