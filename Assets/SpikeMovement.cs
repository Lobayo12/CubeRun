using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 5.0f;
    private Transform target;
    public Rigidbody2D rb;

    void Start()
    {
        target = pointB;
        rb.gravityScale = 0; // Ensure no gravity affects the movement
    }

    void FixedUpdate()
    {
        // Convert the target position from Vector3 to Vector2
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);

        // Move smoothly towards the target
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        // Switch target when close enough
        if (Vector2.Distance(rb.position, targetPosition) < 0.01f) // More precise threshold
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
