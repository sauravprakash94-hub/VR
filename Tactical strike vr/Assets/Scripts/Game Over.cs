using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void TriggerGameOver()
    {
        Debug.Log("Game Over Triggered");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Debug.Log("Restart Level clicked. Loading Level 1 via Index.");

        Time.timeScale = 1f;

        // This will strictly load the scene at Index 1 (which is your Level 1)
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); // Main Menu
    }

    public void QuitGame()
    {
        Debug.Log("Quit button pressed! Exiting the game instantly.");
        Application.Quit();
    }

}