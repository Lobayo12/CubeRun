using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;  // Reference to the player

    [SerializeField]
    private float followSpeed = 5f;  // Speed at which the camera follows

    [SerializeField]
    private Vector3 offset;  // Offset from the player

    private float fixedY;  // Fixed Y position for the camera

    void Start()
    {
        Debug.Log("CameraMovement script started.");

        // Initialize the player transform if not set
        if (playerTransform == null)
        {
            Debug.Log("PlayerTransform is null. Attempting to find the player...");
            FindPlayer();
        }
        else
        {
            Debug.Log($"PlayerTransform already assigned: {playerTransform.name}");
        }

        // Set the fixed Y position for the camera
        fixedY = transform.position.y;
        Debug.Log($"Camera's fixed Y position set to: {fixedY}");
    }

    void LateUpdate()
    {
        // Check if the game is 'playing' and if the player transform is assigned
        if (SceneLoad.Instance != null /*&& SceneLoad.Instance.playing*/ && playerTransform != null)
        {
            // Move the camera to follow the player
            Vector3 targetPosition = new Vector3(playerTransform.position.x + offset.x, fixedY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            Debug.Log($"Camera moved to: {transform.position}");
        }
        else
        {
            Debug.LogWarning("Camera movement is disabled.");
        }
    }

    // Attempt to find the player in the scene
    private void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
            Debug.Log($"Player found and assigned: {player.name}");
        }
        else
        {
            Debug.LogError("No GameObject with the 'Player' tag found in the scene!");
        }
    }
}
