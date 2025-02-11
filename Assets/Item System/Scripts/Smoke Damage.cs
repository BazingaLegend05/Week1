using UnityEngine;

public class SmokeDamage : MonoBehaviour
{
    private bool isPlayerInSmoke = false; // Whether the player is in the smoke area
    private HealthManager playerHealth;   // Reference to the player's HealthManager

    private float damageTimer = 0f;  // Timer to track when 1 second has passed

    void OnTriggerEnter(Collider other)
    {
        // When the player enters the smoke area
        if (other.CompareTag("Player"))  // Ensure the player is tagged as "Player"
        {
            playerHealth = other.GetComponent<HealthManager>();  // Get the HealthManager component from the player
            if (playerHealth != null)
            {
                isPlayerInSmoke = true;  // Player is inside the smoke
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // When the player leaves the smoke area
        if (other.CompareTag("Player"))
        {
            isPlayerInSmoke = false;  // Stop applying damage when the player leaves the smoke
        }
    }

    void Update()
    {
        if (isPlayerInSmoke && playerHealth != null)
        {
            // Increase the timer every frame
            damageTimer += Time.deltaTime;

            // If 1 second has passed, apply exactly 1 damage to the player
            if (damageTimer >= 1f)
            {
                playerHealth.Hit(1f);  // Apply 1 damage
                damageTimer = 0f;  // Reset the timer
            }
        }
    }
}
