using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{
    public Camera playerCamera; // Renamed to avoid conflict

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

        if (Input.GetKey("up"))
        {
            transform.Translate(forward * 0.01f, Space.World);
        }

        if (Input.GetKey("down"))
        {
            transform.Translate(-forward * 0.01f, Space.World);
        }
        
        if (Input.GetKey("left"))
        {
            transform.Translate(-right * 0.01f, Space.World);
        }

        if (Input.GetKey("right"))
        {
            transform.Translate(right * 0.01f, Space.World);
        }
    }
}
