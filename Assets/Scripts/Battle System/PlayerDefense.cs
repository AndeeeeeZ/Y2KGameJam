using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    [SerializeField] private bool DEBUG = false;
    private PlayerEnergy energy;

    public bool isHoldLeft { get; private set; }
    public bool isHoldRight { get; private set; }

    private void Awake()
    {
        energy = GetComponent<PlayerEnergy>();
        Reset();
    }

    // Value for performing or canceling block
    public void RequestBlock(Direction direction, bool value)
    {
        if (DEBUG)
            Debug.Log($"Player requested to defense {direction} with value {value}");

        if (value && !energy.CanBlock()) // If trying to start block & can't block
        {
            if (DEBUG)
                Debug.LogWarning("Cannot block due to no energy");
            return;
        }

        // TODO: call energy's StartDefending() or smt like that when start defending

        if (direction == Direction.LEFT)
        {
            isHoldLeft = value;
        }
        else if (direction == Direction.RIGHT)
        {
            isHoldRight = value;
        }
    }

    public void UpdateDefense()
    {
        energy.UpdateEnergy(isHoldLeft, isHoldRight);
    }

    public void Reset()
    {
        isHoldLeft = false;
        isHoldRight = false;
        energy.Reset();
    }
}
