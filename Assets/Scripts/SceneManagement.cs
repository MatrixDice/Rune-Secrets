using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;
using UnityEngine.SceneManagement; // add to be able to load next scene

public class SceneManagement : MonoBehaviour
{
    public static int q = 0; // Save screen nr for Game Over scene

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0); // Load scene 0 - Main menu scene
    }

    public void PlayScene1()
    {
        SceneManager.LoadSceneAsync(1); // Load scene 1 - 1st game scene
    }

    public void PlayScene2()
    {
        SceneManager.LoadSceneAsync(2); // Load scene 1 - 2nd game scene
    }

    public void PlayScene3()
    {
        SceneManager.LoadSceneAsync(3); // Load scene 1 - 3rd game scene
    }

    public void YouWon()
    {
        SceneManager.LoadSceneAsync(4); // Load scene 4 - You won!
    }

    public void Options()
    {
        SceneManager.LoadSceneAsync(5); // Load scene 5 - Options scene
    }

    public void QuitGame() // Quit
    {
#if UNITY_WEBGL // Web browser
        Application.OpenURL("https://matrixdice.itch.io/rune-secrets"); //URL to be able to quit
#else
        Application.Quit();
#endif
    }

    public void GameOver() // Game over Scene
    {
        int y = SceneManager.GetActiveScene().buildIndex; // get active scene
        q = y; // Save scene nr (q, static) to be fetched in this script SceneManagement.cs Continue()
                
        //RunestoneReveal.open = false; // Set runestone open to false
        //CoinCollector.coins = 0;

        SceneManager.LoadSceneAsync(6); // Load scene 6 - Game over scene
    }

    public void Continue() // Game over Scene - Continue
    {
        int y = SceneManagement.q; // Get q variable saved in this script when Game over
        Debug.Log("Continue, Scene: " + q);
        
        //RunestoneReveal.open = false; // Set runestone open to false

        SceneManager.LoadSceneAsync(y);
    }
}
