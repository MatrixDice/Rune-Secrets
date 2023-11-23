using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clip;
    public float volume = 0.7f;

    /*
    // On collision enter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if(collision.gameObject.name) // Name of the object tex player
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")){ // GetMask funkar ibland
            print("Player collided with me");
        }  
    }

    // On collision exit
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        { 
            print("Player stop colliding with me");
        }
    }
    */

    // Trigger instead of collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Count coins
            CoinCollector coinCollector = collision.GetComponent<CoinCollector>(); // Script CoinCollector
            coinCollector.AddCoin();

            // Score bar 
            //ScoreText.coinAmount += 1; // Script ScoreText 

            // Coin sound
            audioSource.PlayOneShot(audioSource.clip, volume);

            //print("Player triggered me");

            // Set the tick of Coin - Coin disappears when running into it
            gameObject.SetActive(false);   //gameObject of the coin itself, not the object collided with it
        }
    }
}