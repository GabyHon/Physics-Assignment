using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadStartingScene()
    {
        SceneManager.LoadScene(0);
    }

    /*public void LoadWinGameOver()
    {
        SceneManager.LoadScene(2);
    }*/

    /*public void LoadLoseGameOver()
    {
        SceneManager.LoadScene(3);
    }*/

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting the game");
    }
}

// itch.io link
// https://gaby-hon.itch.io/physics-assignment-air-hockey
