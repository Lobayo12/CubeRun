using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float followSpeed = 5f;

    [SerializeField]
    private Vector3 offset;

    private float fixedY;

    void Start()
    {
        Debug.Log("CameraMovement script started.");

        // Assign playerTransform if not already set in the inspector
        if (playerTransform == null)
        {
            Debug.Log("PlayerTransform is null. Attempting to find the player...");
            FindPlayer();
        }
        else
        {
            Debug.Log($"PlayerTransform already assigned: {playerTransform.name}");
        }

        // Ensure the Y position is locked
        fixedY = transform.position.y;
        Debug.Log($"Camera's fixed Y position set to: {fixedY}");

        // Log the initial state of SceneLoad.Instance.playing
        if (SceneLoad.Instance != null)
        {
            Debug.Log($"SceneLoad.Instance.playing = {SceneLoad.Instance.playing}");
        }
        else
        {
            Debug.LogWarning("SceneLoad.Instance is null! Ensure SceneLoad exists and is persistent across scenes.");
        }
    }

    void LateUpdate()
    {
        Debug.Log("LateUpdate called.");

        // Check if SceneLoad.Instance is available and playing is true
        if (SceneLoad.Instance != null && SceneLoad.Instance.playing)
        {
            Debug.Log("Camera is allowed to move (SceneLoad.Instance.playing is true).");

            // Check if playerTransform is assigned
            if (playerTransform != null)
            {
                // Update camera position
                Vector3 targetPosition = new Vector3(playerTransform.position.x + offset.x, fixedY, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

                Debug.Log($"Camera moved to: {transform.position}");
            }
            else
            {
                Debug.LogError("playerTransform is null! Camera cannot follow the player.");
            }
        }
        else
        {
            Debug.LogWarning("Camera movement is disabled because SceneLoad.Instance is null or playing is false.");
        }

        if (SceneLoad.Instance != null && SceneLoad.Instance.playing && playerTransform != null)
        {
            Vector3 targetPosition = new Vector3(playerTransform.position.x + offset.x, fixedY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            Debug.Log($"Camera moved to: {transform.position}");
        }
        else
        {
            Debug.LogWarning("Camera did not move. Check SceneLoad.Instance and playerTransform.");
        }

    }

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
