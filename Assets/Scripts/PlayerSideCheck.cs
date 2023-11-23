using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideCheck : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clip;
    public float volume = 0.8f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Don't / Why sound 
            audioSource.PlayOneShot(audioSource.clip, volume);
        }
    }
}