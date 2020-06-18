using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreMovement : MonoBehaviour
{
    public int spacesY = 3; //Size of array Columns
    public int spacesX = 3; //Size of array Rows
    public GameObject player;
    public List<GameObject> spacesInput = new List<GameObject>(); //For taking the objects in from the inspector
    public GameObject[,] spaces = new GameObject[3,3]; //The array of possitions
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
            for(int i = 0; i < spacesY; i++)
            {
                for(int j = 0; j < spacesX; j++)
                {
                    //Debug.Log(i + " " + j); //Used for debuging array asigning.
                    spaces[j,i] = spacesInput[listElement];
                    listElement++; //Move on to the next element of the list.
                }
            }
            
            //Set the starting point for the player. (at the moment coordinate 1,1)
            currentX = 1;
            currentY = 1;
            player.transform.position = spaces[currentX,currentY].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) //Right movement
        {
            //Check if space to move to exists
            if (currentX+1 < spacesX)
            {
                currentX++; //Update variable representing it's position
                //Move the player
                player.transform.position = spaces[currentX,currentY].transform.position;
                //Debug.Log(currentX + "," + currentY); //Uncomment to display position as you move
            }
        }
        else if (Input.GetKeyDown(KeyCode.A)) //Left movement
        {
            if (currentX-1 >= 0)
            {
                currentX--;
                player.transform.position = spaces[currentX,currentY].transform.position;
                //Debug.Log(currentX + "," + currentY); //Uncomment to display position as you move
            }
        }
        else if (Input.GetKeyDown(KeyCode.W)) //Up movement
        {
            if (currentY-1 >= 0)
            {
                currentY--;
                player.transform.position = spaces[currentX,currentY].transform.position;
                //Debug.Log(currentX + "," + currentY); //Uncomment to display position as you move
            }
        }
        else if (Input.GetKeyDown(KeyCode.S)) //Down movement
        {
            if (currentY+1 < spacesY)
            {
                currentY++;
                player.transform.position = spaces[currentX,currentY].transform.position;
                //Debug.Log(currentX + "," + currentY); //Uncomment to display position as you move
            }
        }
    }
}
