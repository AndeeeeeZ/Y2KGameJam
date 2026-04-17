using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthUI; 
    [SerializeField] private int maxHealth; 
    private int currHealth;

    private void Awake()
    {
        currHealth = maxHealth; 
        UpdateHealthUI();
    }

    public void TakeHit()
    {
        currHealth--; 
        if (currHealth <= 0)
        {
            Die(); 
        }
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        healthUI.text = currHealth.ToString(); 
    }

    private void Die()
    {
        Debug.Log("PLAYER DIED, GAME ENDS"); 
    }
}
