using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrnRuinFlowers : MonoBehaviour
{
    public Animator animator; // control animators through the player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Animation: ruin flowers
            animator.SetBool("Ruin", true);
        }
    }
}