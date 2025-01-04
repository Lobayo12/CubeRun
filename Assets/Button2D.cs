using UnityEngine;
using UnityEngine.SceneManagement;

public class Button2D : MonoBehaviour
{
    public void StartGame(string sceneName)
    {
        if (SceneLoad.Instance != null)
        {
            SceneLoad.Instance.playing = true;
            Debug.Log("SceneLoad.Instance.playing set to true");
        }
        else
        {
            Debug.LogError("SceneLoad.Instance is null!");
        }

        // Load the target scene
        SceneManager.LoadScene(sceneName);
        Debug.Log($"Scene {sceneName} is loading...");
    }

    private void OnMouseDown()
    {
        StartGame("Level1"); // Replace with your scene name
    }
}




