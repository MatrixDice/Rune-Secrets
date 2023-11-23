using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // add to be able to get active scene

public class RunestoneReveal : MonoBehaviour
{
    [SerializeField] GameObject[] veilObject = new GameObject[1];    // Veil
    [SerializeField] GameObject[] groundObjects = new GameObject[6]; // Scene 1: Platforms when 3 coins 
    [SerializeField] GameObject[] groundMoving = new GameObject[1];  // Scene 3: Moving platform when 3 coins
    [SerializeField] GameObject[] star = new GameObject[1];          // Scene 3: Star tinkle
    [SerializeField] GameObject[] coinObjects = new GameObject[3];   // The 3 small coins shall disappear

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.7f;
    
    public Animator animator; 

    public static bool runesOpen; // No sound when runestone already is open

    public void Start()
    {
        animator.SetBool("Reveal", false); // Runestone
        runesOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            int coins = CoinCollector.coins; // Get coins variable saved in script CoinCollector.cs as static
            //Debug.Log("Antal mynt: " + coins);

            if (coins == 3)  //  && open == false If 3 coins and First time the runestone is revealing its runes
            {
                // Set the small coins to inactive when paying the runestone the 3 coins, the coins shall disappear
                coinObjects[0].SetActive(false);
                coinObjects[1].SetActive(false);
                coinObjects[2].SetActive(false);

                if (runesOpen == false) 
                { 
                // Runestone reveal sound
                    audioSource.PlayOneShot(audioSource.clip, volume);
                    runesOpen = true;
                }

                // Animation: stars
                animator.SetBool("Reveal", true);

                // Set the veil to inactive (active from beginning), so the runes are displayed behind the veil
                veilObject[0].SetActive(false);

                // Check which scene
                int y = SceneManager.GetActiveScene().buildIndex;

                if (y == 1) // Scene 1
                {
                     // When the runes are displayed in scene 1:
                     // Set the ground platforms to active (inactive from beginning) to get UP to the portal
                     groundObjects[0].SetActive(true);
                     groundObjects[1].SetActive(true);
                     groundObjects[2].SetActive(true);
                     groundObjects[3].SetActive(true);
                     groundObjects[4].SetActive(true);
                     groundObjects[5].SetActive(true);
                }
                else if (y == 3) // Scene 3
                {
                    // When the runes are displayed in scene 3:
                    // Set the mvoing platform to active (inactive from beginning) to get to the BIG STAR (portal)
                    groundMoving[0].SetActive(true);

                    // The star is vibrating
                    //star[0].SetActive(true);
                    //animator.SetBool("Tink", true);

                    // Start the animation of tinkle star in script Portal.cs function StarTinkle()
                    FindObjectOfType<Portal>().StarTinkle();
                }
            }
        }
    }
}