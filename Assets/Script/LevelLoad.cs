using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    public void StartGame()
    {
        if (SceneLoad.Instance != null)
        {
            SceneLoad.Instance.playing = true; // Set the `playing` variable to true
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene"); // Load the game scene
    }


    public void WhenLevel1Pressed()
    {
        SceneManager.LoadScene("Level1");
    }

    public void WhenLevel2Pressed()
    {
        SceneManager.LoadScene("Level2");
    }

    public void WhenLevel3Pressed()
    {
        SceneManager.LoadScene("Level3");
    }

    public void WhenLevel4Pressed()
    {
        SceneManager.LoadScene("Level4");
    }

    public void WhenLevel5Pressed()
    {
        SceneManager.LoadScene("Level5");
    }

    public void WhenLevel6Pressed()
    {
        SceneManager.LoadScene("Level6");
    }

    public void WhenLevel7Pressed()
    {
        SceneManager.LoadScene("Level7");
    }

    public void WhenLevel8Pressed()
    {
        SceneManager.LoadScene("Level8");
    }

    public void WhenLevel9Pressed()
    {
        SceneManager.LoadScene("Level9");
    }

    public void WhenLevel10Pressed()
    {
        SceneManager.LoadScene("Level10");
    }
}
