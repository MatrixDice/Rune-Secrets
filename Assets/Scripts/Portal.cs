using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // add to be able to load next scene

public class Portal : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clip;
    public float volume = 0.7f;

    public Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if player trigger the portal to come to next scene
           if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
           {
               // Next scene
               int y = SceneManager.GetActiveScene().buildIndex;
               y++;
               SceneManager.LoadSceneAsync(y);

               // Portal - warp sound
               audioSource.PlayOneShot(audioSource.clip, volume);
        }
    }

    public void StarTinkle() // Called function from RunestoneReveal.cs when revealing the runes
    {
        animator.SetBool("Tink", true);
    }
}
