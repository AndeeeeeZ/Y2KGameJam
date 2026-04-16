using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth; 
    private int currHealth;

    private void Awake()
    {
        currHealth = maxHealth; 
    }

    public void TakeHit()
    {
        currHealth--; 
        if (currHealth <= 0)
        {
            Die(); 
        }
    }

    private void Die()
    {
        // TODO: End round
    }
}
