using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] private Player player1, player2; 
    
    [Header("Match Stats")]
    [SerializeField] private float matchTime; 

    private Player currAttacker, currDefender; 

    private float currentTime; 

    private void Update()
    {
        UpdateTimer(); 
    }

    private void UpdateTimer()
    {
        
    }


}
