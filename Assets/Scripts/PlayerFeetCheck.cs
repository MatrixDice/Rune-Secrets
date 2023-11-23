using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFeetCheck : MonoBehaviour
{
    //[SerializeField] Rigidbody2D rb;

    //private float dirX;
    //private float moveSpeed;
/*
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 1f;
*/
    public Animator animator;

    //public float delayTime = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Oh no sound
            // audioSource.PlayOneShot(audioSource.clip, volume);

            StartCoroutine(DelayedCodeExecution());
        }
    }

    IEnumerator DelayedCodeExecution()
    {
    Debug.Log("This code is executed immediately");

    // Animation: poof
    animator.SetBool("Poof", true);

        yield return new WaitForSeconds(0.3f);

    Debug.Log("This code is executed after 0,3 seconds");

    // Delay the destruction of the game object
    Destroy(transform.parent.gameObject); // Remove game object Enemy
    }
}
