using UnityEngine;

public class Health : MonoBehaviour
{
    private HealthManager playerHealth;
    private void OnTriggerEnter(Collider other)
    {
        Use();
        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<HealthManager>();
            if (playerHealth != null)
            {
                playerHealth.MedKit(15f);
            }
        }
    }
    void Use()
    {
        Debug.Log("Using " + transform.name);
        Destroy(gameObject);
            
    }
}
