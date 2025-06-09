using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    public void Backbutton()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
}
