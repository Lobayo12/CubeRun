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
        fixedY = transform.position.y;
    }

    void LateUpdate()
    {
        if (SceneLoad.Instance.playing)
        {
            // The camera follows the player horizontally
            Vector3 targetPosition = new Vector3(playerTransform.position.x + offset.x, fixedY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
