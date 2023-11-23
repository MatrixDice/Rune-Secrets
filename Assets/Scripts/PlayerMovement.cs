using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController controller; // CharacterController2D not available

    //bool jump = false;
    //bool crouch = false;
    //bool flip = false;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    public Animator animator; // control animators through the player

    // public PlayerController playerController; //Script that contains the bools variables isJumping, isTouchingGround


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // From youtube "2D Animation"
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); // Set speed, Abs = alltid +värde

        if (horizontalMove > 0)
        {
            animator.SetBool("Flip", false);
        }
        else if (horizontalMove < 0)
        {
            animator.SetBool("Flip", true);
        }
        
        /*
        // Check from script PlayerController.cs if Jumping or touching ground - Funkar ej!!
        if (playerController.isTouchingGround == true)
        {
            animator.SetBool("IsJumping", false); // Touching ground Public bool
        }
        else if (playerController.isJumping == true)
        {
            animator.SetBool("IsJumping", true); // Jumping
        }
        */


        /*
                    if (Input.GetButtonDown("Jump"))
                    {
                        jump = true;
                        animator.SetBool("IsJumping", true);
                    }

                    if (Input.GetButtonDown("Crouch"))
                    {
                        crouch = true;
                    } elseif (Input.GetButtonUp("Crouch"))
                    {
                        crouch = false;
                    }

            void FixedUpdate()
            // Move our character
            {
                controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
                jump = false;
            }


        }
        public void OnLanding()
        {
            animator.SetBool("IsJumping", false); // when event "On Land event"
        */
    }
}


