using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // add to be able to load next scene

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigidbody;
    [SerializeField] float movementSpeed = 10.0f;
    [SerializeField] float movementSpeed2 = 15.0f;
    [SerializeField] float jumpingSpeed = 8.0f;
   // [SerializeField] Transform flip; // the player flip when left/right

    private float speed = 15.0f; // the speed at which the object moves downward

    private float previousTime;
    public float fallTime = 0.8f;

    public bool isJumping;
    public bool isTouchingGround;


    // Update is called once per frame
    void Update()
    {
        // Handle input
        Vector2 inputDir = Vector2.zero;
        
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // Go right: D or Right arrow
        {
            inputDir.x += 1.0f;
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // Go left: A or Left arrow
        {
            inputDir.x -= 1.0f;
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) // Go down faster: S or Down arrow
        {
            myRigidbody.AddForce(Vector2.down * speed, ForceMode2D.Impulse);   
        }
        
        // Handle jump
        bool recievedJumpInput = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)); // W or Up arrow, GetKeyDown för 1 hopp, GetKey flera hopp
        bool touchingGround = myRigidbody.IsTouchingLayers();

        if (recievedJumpInput && touchingGround)
        {
            myRigidbody.AddForce(Vector2.up * jumpingSpeed, ForceMode2D.Impulse); // Impulse = quick kickup and don't do that again
        }

        // Apply Velocity

        if (Input.GetKey(KeyCode.Space)) // Go left/right faster: Space (creates null reference, but is working)
        {
            Vector2 moveDir = inputDir * movementSpeed2;
            moveDir.y = myRigidbody.velocity.y;
            myRigidbody.velocity = moveDir;
        }
        else
        {
            Vector2 moveDir = inputDir * movementSpeed; // Normal speed
            moveDir.y = myRigidbody.velocity.y;
            myRigidbody.velocity = moveDir;
        }

        // Quit
        if (Input.GetKey(KeyCode.Escape)) // Escape
        {
                // Application.Quit(); // Doesn't always work!

                // Go to SceneManagement.cs Main menu and exit there with already existing funktion QuitGame()
                FindObjectOfType<SceneManagement>().MainMenu(); // Script SceneManagement, funktion Main menu - GameOver scene
        }

        // Off scene - Game Over
        Vector3 pos = transform.position;

        //Debug.Log("Player position: " + pos);

        if (pos.y <= -4.0f)
        {
            FindObjectOfType<SceneManagement>().GameOver(); // Script SceneManagement, funktion GameOver
        }
    }
}