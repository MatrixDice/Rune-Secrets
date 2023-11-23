using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Do not working!
public class EnemyHeadCheck : MonoBehaviour
{
    //private Rigidbody2D myRigidbody;
    //private GameObject playerObject;
    [SerializeField]
    private Rigidbody2D playerRb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.GetComponent<PlayerFeetCheck>()) 
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //Debug.Log(myRigidbody);
            //Rigidbody2D myRigidbody = playerObject.GetComponent<Rigidbody2D>(); // rigidbody has to be static in PlayerController.cs
            playerRb.velocity = new Vector2(playerRb.velocity.x, 0f);
            playerRb.AddForce(Vector2.up * 30f);
        }
    }
}