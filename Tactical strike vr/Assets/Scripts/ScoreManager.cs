using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Required to talk to TextMeshPro UI

public class ScoreManager : MonoBehaviour
{
    [Header("Score Settings")]
    public int currentScore = 0;
    public int targetScore = 100;
    public int finishedSceneIndex = 2; // Matches your Build Settings

    [Header("UI Display")]
    [Tooltip("Drag your Text (TMP) object here from the Hierarchy")]
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Set the text to 0 when the level starts
        UpdateScoreDisplay();
    }

    public void AddScore(int pointsToAdd)
    {
        currentScore += pointsToAdd;
        Debug.Log("Score updated! Current: " + currentScore);

        UpdateScoreDisplay();

        // Check if player won
        if (currentScore >= targetScore)
        {
            Debug.Log("Loading Finished Scene...");
            SceneManager.LoadScene(finishedSceneIndex);
        }
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore + " / " + targetScore;
        }
    }
}