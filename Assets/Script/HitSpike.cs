using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this for scene management

public class HitSpike : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb; // Reference to the player's Rigidbody2D
    private PlayerMovement playerMovement; // Reference to the PlayerMovement script

    private bool isAnimationTriggered = false; // Flag to check if the animation is already triggered

    public string levelSceneName = "Level1"; // The name of the level scene to load

    private void Start()
    {
        // Get the Animator component attached to the Player
        animator = GetComponent<Animator>();

        // Get the Rigidbody2D component to stop movement
        rb = GetComponent<Rigidbody2D>();

        // Get the PlayerMovement script to disable it
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Collision detected with {collision.gameObject.name}");

        // Check if the object collided with has the tag "Spike" and if animation is not triggered yet
        if (collision.gameObject.CompareTag("Spike") && !isAnimationTriggered)
        {
            Debug.Log("Player hit a spike! Disappearing...");

            // Set the flag to true to prevent re-triggering the animation
            isAnimationTriggered = true;

            // Trigger the disappear animation
            animator.SetTrigger("DisappearTrigger");

            // Freeze the player's movement (stop velocity)
            rb.linearVelocity = Vector2.zero; // Stop the player's velocity
            rb.constraints = RigidbodyConstraints2D.FreezeAll; // Freeze all movement (position and rotation)

            // Disable the movement script to stop further input
            playerMovement.enabled = false;

            // Start the coroutine to handle player disappearance and scene load
            StartCoroutine(HandlePlayerDisappearance());
        }
        else
        {
            Debug.Log("Collided with a non-Spike object");
        }
    }

    private IEnumerator HandlePlayerDisappearance()
    {
        // Wait for the animation to complete (adjust based on your animation length)
        yield return new WaitForSeconds(1f); // Wait for 1 second (or the length of your animation)

        // Load the scene (level) after the animation finishes
        Debug.Log("Loading the level scene...");

        // Load the specified level scene
        SceneManager.LoadScene(levelSceneName);

        // Optionally, deactivate player (though this is not necessary since the scene will load)
        gameObject.SetActive(false);
    }
}







