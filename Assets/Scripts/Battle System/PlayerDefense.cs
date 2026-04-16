using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    // Value for performing or canceling block
    public void RequestBlock(Direction direction, bool value)
    {
        Debug.Log($"Player requested to defense in direction {direction} with value {value}");
    }
}
