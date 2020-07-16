using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherScript : MonoBehaviour
{
    public void GotoKeybindsMenu()
    {
        SceneManager.LoadScene(3);
    }
}
