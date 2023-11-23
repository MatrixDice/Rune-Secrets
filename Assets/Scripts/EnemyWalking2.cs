using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalking2 : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float posXStart = 19.0f;
    [SerializeField] float posXStop = 27.5f;

    private float dirX;
    private float moveSpeed;
    private bool facingRight;
    //private Vector3 localScale;

    private void Start()
    {
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
}