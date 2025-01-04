using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public static SceneLoad Instance;

    public bool playing;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnEnable()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LevelsMenu")
        {
            playing = true;
        }
        else
        {
            playing = false;
        }
    }

    public void WhenPlayPressed()
    {
        // Load the scene when button pressed
        SceneManager.LoadScene("LevelsMenu");
        SceneManager.LoadScene("LevelsMenu");
        playing = true;
        Debug.Log("Playing state set to true");
    }


}
