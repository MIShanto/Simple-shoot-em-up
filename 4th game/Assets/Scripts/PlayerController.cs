using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f; // The speed at which the camera moves
    public Joystick joystick;
    public float leftLimit, rightLimit;

    void Update()
    {
        // Get the mouse input for rotating the camera
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontal, vertical);

        // Normalize movement vector to prevent faster diagonal movement
        movement.Normalize();

        // Move player using the Translate method
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), transform.position.y);
    }

}
