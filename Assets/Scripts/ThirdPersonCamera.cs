using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform orientation; // Player orientation
    public Transform player;
    public Transform playerObj; // Player object
    public Rigidbody rb; // Player rigidbody
    public float rotationSpeed; // Rotation speed

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Rotate the camera based on the player orientation
        UnityEngine.Vector3 viexDir = player.position - new UnityEngine.Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viexDir.normalized;

        // Rotate the player object based on the camera orientation
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        UnityEngine.Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (inputDir != UnityEngine.Vector3.zero)
        {
            playerObj.forward = UnityEngine.Vector3.Slerp(playerObj.forward, inputDir, Time.deltaTime * rotationSpeed);
            
        }

    }

}
