using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clip;
    public float volume = 0.7f;


    // On collision enter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.gameObject.name) // Name of the object tex player
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //print("Player collided with me");

            // Hello sound
            audioSource.PlayOneShot(audioSource.clip, volume);
        }
    }
}
