using UnityEngine;

public class SoulScript : MonoBehaviour
{
    public string playerTag = "PlayerObject"; // Tag assigned to the player object
    private Transform playerTransform; // Reference to the player's transform

    public float fleeRadius = 5.0f; // Radius within which the object starts fleeing from the player
    public float fleeSpeed = 3.0f; // Speed at which the object flees
    public float wallFleeRadius = 2.0f; // Radius within which the object starts fleeing from walls
    public LayerMask wallLayerMask; // Layer mask to identify walls

    void Start()
    {
        // Find the player object by tag and cache the transform
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object with tag '" + playerTag + "' not found.");
        }
    }

    void Update()
    {
        Vector3 fleeDirection = Vector3.zero;

        // Flee from the player
        if (playerTransform != null)
        {
            float playerDistance = Vector3.Distance(transform.position, playerTransform.position);
            if (playerDistance < fleeRadius)
            {
                Vector3 playerFleeDirection = transform.position - playerTransform.position;
                fleeDirection += playerFleeDirection.normalized;
            }
        }

        // Flee from walls
        Collider[] walls = Physics.OverlapSphere(transform.position, wallFleeRadius, wallLayerMask);
        foreach (Collider wall in walls)
        {
            Vector3 wallFleeDirection = transform.position - wall.transform.position;
            fleeDirection += wallFleeDirection.normalized;
        }

        // If there is a flee direction, move the object
        if (fleeDirection != Vector3.zero)
        {
            fleeDirection.Normalize();
            transform.position += fleeDirection * fleeSpeed * Time.deltaTime;
        }
    }
}
