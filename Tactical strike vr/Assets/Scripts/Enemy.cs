using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("Health")]
    public int health = 100;

    [Header("Score Settings")]
    [Tooltip("How many points this enemy gives when destroyed")]
    public int pointsValue = 50;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(gameObject.name + " took " + amount + " damage. HP left: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died!");

        // Find the ScoreManager in your scene and give it the points!
        ScoreManager gameManager = Object.FindFirstObjectByType<ScoreManager>();

        if (gameManager != null)
        {
            gameManager.AddScore(pointsValue);
        }
        else
        {
            Debug.LogWarning("No ScoreManager found in the scene!");
        }

        // Destroy the enemy AFTER giving the points
        Destroy(gameObject);
    }
}