using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Does not work!!!

public class YouWonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1f;
        
    public AudioSource audioSource2;
    public AudioClip clip2;
    public float volume2 = 0.5f;
    
    //public float delayTime = 2f; 
    

    public void Update()
    {
        Debug.Log("win sound");
    // Win sound
    //audioSource.PlayOneShot(audioSource.clip, volume); // awake instead

    // Delay the next sound
    //StartCoroutine(DelayedCodeExecution());
    }
    
     IEnumerator DelayedCodeExecution()
     {
             Debug.Log("This code is executed immediately");

             yield return new WaitForSeconds(3.0f);

             Debug.Log("This code is executed after 3 seconds");

             audioSource2.PlayOneShot(audioSource2.clip, volume2);
     }
}