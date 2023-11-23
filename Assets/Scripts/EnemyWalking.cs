using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
   [SerializeField] Rigidbody2D rb;
   [SerializeField] float posXStart = 22.0f;
   [SerializeField] float posXStop = 73.0f;

   private float dirX;
   private float moveSpeed;
   private bool facingRight;
   //private Vector3 localScale;

   private void Start()
   {
       //localScale = transform.localScale; // get inspector's Transform (position, not scale)
       dirX = 1f;                         // move in direction, x with positive value is to the right
       moveSpeed = 3f;                    // speed to move in that direction
       facingRight = true;
   }

   void Update()
   {
       //Walking: x direction, speed. y shall be the same.
       rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

       //Pos x value from serializefield (different in scene1, 2, 3.)
       Vector3 pos = transform.position;

        /*
        if (pos.x <= posXStart || pos.x >= posXStop)
        {
             //Debug.Log("pos.x: " + pos.x);
             //dirX *= -1f; // update cannot be done here, stands still, goto FixedUpdate()
             StartCoroutine(DelayedCodeExecution());
        }
        */

        if (pos.x >= posXStop && facingRight == true)
        {
            facingRight = false;
            dirX *= -1f;

        }

        if (pos.x <= posXStart && facingRight == false)
       {
            facingRight = true;
            dirX *= -1f;
        }
    }

   private void FixedUpdate()
   {
        // Direct update - Physics
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
   }
    /*
    IEnumerator DelayedCodeExecution()
    {
        //Debug.Log("This code is executed immediately");
        dirX *= -1f;// update cannot be done here, stands still, goto FixedUpdate() - call 2 times per frame

        //Debug.Log("This code is executed after 1.5 seconds");
        yield return new WaitForSeconds(1.5f);
    }
    */
}