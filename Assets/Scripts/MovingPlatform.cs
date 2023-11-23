using UnityEngine;

// Does not work!
public class FollowMovingPlatform : MonoBehaviour
{
    private Transform player;
    private Vector3 lastPlatformPosition; // Stores the position of the platform in the last frame

    private void Start()
    {
        player = transform; // Assign the player transform
    }

    private void FixedUpdate()
    {
        Vector3 platformMovement = transform.position - lastPlatformPosition; // Calculate the relative movement of the platform
        player.position += platformMovement; // Apply the relative movement to the player's position
        lastPlatformPosition = transform.position; // Update the last platform position for the next frame
    }
}