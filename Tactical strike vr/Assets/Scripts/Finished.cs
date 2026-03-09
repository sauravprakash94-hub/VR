using UnityEngine;
using UnityEngine.SceneManagement;

public class Finished : MonoBehaviour
{
   //Replay level
    public void RestartLevel()
    {
        Debug.Log("Replay button clicked. Loading Level 1 (Index 1).");
        Time.timeScale = 1f;

        // Strictly loads Level 1 using its Build Index number (1)
        SceneManager.LoadScene(1);
    }

    // Hook this up to your Quit button
    public void QuitGame()
    {
        Debug.Log("Quit button pressed! Exiting the game instantly.");
        Application.Quit();
    }
}
