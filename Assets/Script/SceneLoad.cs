using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public static SceneLoad Instance;  // Singleton instance
    public bool playing = false;      // Tracks the "playing" state

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Ensures the object stays across scenes
            Debug.Log("SceneLoad Singleton Initialized");
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnEnable()
    {
        // Subscribe to scene loading events
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"OnSceneLoaded triggered. Scene: {scene.name}, playing set to: {playing}");

        if (scene.name == "LevelsMenu")
        {
            playing = true;  // Set playing to true for "LevelsMenu"
        }
        else
        {
            playing = false; // Otherwise, set it to false
        }
    }


    public void WhenPlayPressed()
    {
        Debug.Log("Button pressed: Setting playing to true");
        SceneLoad.Instance.playing = true;
        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(0.1f); // Delay for one frame
        SceneManager.LoadScene("LevelsMenu");
        Debug.Log("SceneLoad: LevelsMenu loaded");
    }

}

