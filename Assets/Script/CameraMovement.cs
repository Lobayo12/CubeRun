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
        void Start()
        {
            if (playerTransform == null)
            {
                playerTransform = GameObject.FindWithTag("Player")?.transform;

                if (playerTransform != null)
                {
                    Debug.Log($"Player Transform dynamically assigned: {playerTransform.name}");
                }
                else
                {
                    Debug.LogWarning("No GameObject with the 'Player' tag found!");
                }
            }
            fixedY = transform.position.y;
        }

    }

    void LateUpdate()
    {
        if (playerTransform != null)
        {
            Debug.Log($"Player Position: {playerTransform.position}");

            if (SceneLoad.Instance.playing)
            {
                Debug.Log("Camera is moving.");

                // Update camera position
                Vector3 targetPosition = new Vector3(playerTransform.position.x + offset.x, fixedY, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

                Debug.Log($"Camera Position: {transform.position}");
            }
        }
        else
        {
            Debug.LogWarning("Player Transform is NOT assigned!");
        }
    }




    private void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Look for the Player by tag
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene. Ensure the player has the 'Player' tag.");
        }
    }
}

