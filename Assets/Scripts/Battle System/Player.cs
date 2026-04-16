using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public MatchManager matchManager; 
    [SerializeField] public PlayerRole currentRole;
    private PlayerCombat combat; 
    private PlayerDefense defense;
    private PlayerHealth health; 

    private void Awake()
    {
        combat = GetComponent<PlayerCombat>(); 
        defense = GetComponent<PlayerDefense>(); 
        health = GetComponent<PlayerHealth>(); 
    }

    private void Start()
    {
        Reset(); 
    }

    private void Update()
    {
        if (currentRole == PlayerRole.ATTACKER)
            combat.UpdateCombat(); 
        else if (currentRole == PlayerRole.DEFENDER)
            defense.UpdateDefense(); 
    }

    public void Reset()
    {
        combat.Reset(); 
        defense.Reset(); 
    }

}   


