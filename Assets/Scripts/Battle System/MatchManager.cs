using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] private Player player1, player2; 
    
    [Header("Match Stats")]
    [SerializeField] private float matchTime; 

    private Player currAttacker, currDefender; 

    private float currentTime; 
    private bool isRunning; 

    private void Update()
    {
        UpdateTimer(); 
    }

    private void UpdateTimer()
    {
        if (!isRunning) return; 

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f; 
            isRunning = false; 
        } 


    }

    public void OnTurnEnds()
    {
        SwapPlayerRoles(); 
    }

    private void SwapPlayerRoles()
    {
        
    }


}
