using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // add to be able to load next scene


public class CoinCollector : MonoBehaviour
{
    [SerializeField] GameObject[] coinObjects = new GameObject[3]; // Create 3 new gameobjects (the small coins)
    public static int coins = 0;

    public void Start()
    {
        coins = 0;
    }

    public void AddCoin()
    {
        // Do not count more than 3 coins
        if (coins < 3)
        {
            // Set the small coins to active (inactive from beginning) 
            //   so they get visible
            coinObjects[coins].SetActive(true);
            coins++;
        }
    }
}