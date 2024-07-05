using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{
    public Camera playerCamera; // Renamed to avoid conflict
    public float gravity = 9.8f; // Gravity force
    public float jumpForce = 10.0f; // Jump force
    private bool isGrounded = true; // Check if the player is on the ground
    private float verticalSpeed = 0; // Speed of vertical movement

    // Start is called before the first frame update
    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned and Main Camera not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned!");
            return;
        }

        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        // We need to ignore the y component to keep the movement on the ground plane
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();
        
        if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            transform.Translate(forward * 0.01f, Space.World);
        }

        if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            transform.Translate(-forward * 0.01f, Space.World);
        }

        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-right * 0.01f, Space.World);
        }

        if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            transform.Translate(right * 0.01f, Space.World);
        }

        // Gravity and jumping logic
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                verticalSpeed = jumpForce;
                isGrounded = false;
            }
            else
            {
                verticalSpeed = 0;
            }
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        // Apply vertical movement
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime, Space.World);

        // Check if the player is grounded
        if (transform.position.y <= 0.5f) // Adjust this value based on your ground level
        {
            isGrounded = true;
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z); // Snap to ground level
        }
    }
}
