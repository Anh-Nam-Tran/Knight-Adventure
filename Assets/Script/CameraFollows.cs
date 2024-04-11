using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform player; // Reference to the player's transform

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Get the player's position
            Vector3 playerPosition = player.position;
            
            // Keep the camera's z-axis position unchanged
            playerPosition.z = transform.position.z;

            // Set the camera's position to the modified player position
            transform.position = playerPosition;
        }
    }
}


