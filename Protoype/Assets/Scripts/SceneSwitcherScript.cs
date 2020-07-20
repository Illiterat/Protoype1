using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherScript : MonoBehaviour
{

    private void Update()
    {
        NextScene();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Will load player into next scene, only works in menu
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0); //Will also load player into menu scene, only works in win screen
    }

    public void GotoKeybindsMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void NextScene()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Will load player into next scene
        }
    }
}
