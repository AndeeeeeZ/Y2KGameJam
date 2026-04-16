using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public void RequestAttack(Direction direction)
    {
        Debug.Log($"Player requested attack in direction {direction}"); 
    }

    public void RequestFake()
    {
        Debug.Log("Player requested fake attack"); 
    }
}
