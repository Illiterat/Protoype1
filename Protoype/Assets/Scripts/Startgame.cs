using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startgame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Will load player into FightScene, only works in menu
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(2); //Will also load player into fight scene, only works in win screen
    }
}
