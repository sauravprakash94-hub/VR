using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Health")]
    public int health = 100;

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
        Destroy(gameObject);
    }
}

