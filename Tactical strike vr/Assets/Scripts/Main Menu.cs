using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // Force 60 FPS so the menu feels smooth on Android
        Application.targetFrameRate = 60;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        // Quits the app (Note: This only works in the final Android build, not in the Unity Editor)
        Application.Quit();
        Debug.Log("Player has quit the game.");
    }
    public void OpenOptions()
    {
        Debug.Log("Quit button was pressed! The game is exiting.");
    }
}

