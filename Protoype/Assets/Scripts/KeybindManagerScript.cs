using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeybindManagerScript : MonoBehaviour
{
    #region Fields
    //Dictionary for storing keybinds
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text upText, leftText, downText, rightText; //Accessing text on menu buttons

    private GameObject currentKey;

    private Color32 normal = Color.white;
    private Color32 selected = new Color32(170, 231, 243, 255); //light blue

    public GameObject warningMessage;
    #endregion

    #region Methods
    #region UnityMethods
    // Start is called before the first frame update
    void Start()
    {
        //Make sure the warning message isn't displaying
        warningMessage.SetActive(false);

        //Add the saved PlayerPrefs for the keys to the Dictionary OR use the default values if there's nothing saved
        keys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));

        //Change the button text to match the keybinds
        upText.text = keys["Up"].ToString();
        downText.text = keys["Down"].ToString();
        leftText.text = keys["Left"].ToString();
        rightText.text = keys["Right"].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking inputs are working correctly
        if (Input.GetKeyDown(keys["Up"]))
        {
            Debug.Log("Up Key Pressed");
        }
    }

    private void OnGUI()
    {
        //Check if there is any currentKey selected
        if (currentKey != null)
        {
            Event e = Event.current;
            KeyCode input = e.keyCode;
            //Checks that the currentKey is actually a key
            //and the input isn't already being used for another key
            if (e.isKey
                && input != keys["Up"]
                && input != keys["Down"]
                && input != keys["Left"]
                && input != keys["Right"]
                )
            {
                //Change the currentKey's name to the key that was just pressed
                keys[currentKey.name] = e.keyCode;
                //Change the text to match the new name
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                //Changes the currentKey color back to normal
                currentKey.GetComponent<Image>().color = normal;

                currentKey = null;
            }
        }
    }
    #endregion
    public void ChangeKey(GameObject clicked)
    {
        //Checks if you've already selected a key
        if (currentKey != null)
        {
            //Change other keys back to their normal color
            currentKey.GetComponent<Image>().color = normal;
        }

        //Sets the current key to the gameObject that was clicked
        currentKey = clicked;
        //Changes the colour to highlight the currentKey
        currentKey.GetComponent<Image>().color = selected;
    }

    public void SaveKeys()
    {
        //For each key in the Dictionary keys
        foreach (var key in keys)
        {
            //Set the value (which is a string) of the current key
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }

    public void SetDefaultKeysWASD()
    {
        //Quickly sets the keys to a standard WASD configuration
        keys["Up"] = KeyCode.W;
        keys["Down"] = KeyCode.S;
        keys["Left"] = KeyCode.A;
        keys["Right"] = KeyCode.D;

        //Updated the text to match the new keybinds
        upText.text = keys["Up"].ToString();
        downText.text = keys["Down"].ToString();
        leftText.text = keys["Left"].ToString();
        rightText.text = keys["Right"].ToString();
    }

    public void SetDefaultKeysArrows()
    {
        //Quickly sets the keys to a standard Arrows configuration
        keys["Up"] = KeyCode.UpArrow;
        keys["Down"] = KeyCode.DownArrow;
        keys["Left"] = KeyCode.LeftArrow;
        keys["Right"] = KeyCode.RightArrow;

        //Updated the text to match the new keybinds
        upText.text = keys["Up"].ToString();
        downText.text = keys["Down"].ToString();
        leftText.text = keys["Left"].ToString();
        rightText.text = keys["Right"].ToString();
    }

    public void ExitKeybindMenu()
    {
        //if current values do NOT equal player prefs, do some stuff
        if (keys["Up"] != (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W"))
            || keys["Down"] != (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "S"))
            || keys["Left"] != (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"))
            || keys["Right"] != (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"))
            )
        {
            Debug.Log("Unsaved Changes");
            warningMessage.SetActive(true);
        }

        else
        {
            //if current values MATCH player prefs, go straight to start
            SceneManager.LoadScene(0); //Goes to start Menu 
        }
    }

    public void SaveAndContinue()
    {
        SaveKeys();
        SceneManager.LoadScene(0);
    }

    public void ContinueWithoutSaving()
    {
        SceneManager.LoadScene(0);
    }

    public void SetWarningInactive()
    {
        warningMessage.SetActive(false);
    }
    #endregion
}
