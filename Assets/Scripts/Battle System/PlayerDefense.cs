using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    [SerializeField] private bool DEBUG = false;
    [SerializeField] private GameObject DEBUG_Left, DEBUG_Right;
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

        if (direction == Direction.LEFT)
        {
            // If input is different from current state
            if (value && !isHoldLeft)
            {
                energy.StartDefending();
                if (value)
                    PutUpHand(Direction.LEFT);
                else
                    PutDownHand(Direction.LEFT);
            }

            isHoldLeft = value;
        }
        else if (direction == Direction.RIGHT)
        {
            // If input is different from current state
            if (value && !isHoldRight)
            {
                energy.StartDefending();
                if (value)
                    PutUpHand(Direction.RIGHT);
                else
                    PutDownHand(Direction.RIGHT);
            }
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

    public void OnNoMoreEnergy()
    {
        PutDownHand(Direction.LEFT);
        PutDownHand(Direction.RIGHT);
    }

    private void PutDownHand(Direction direction)
    {
        if (direction == Direction.LEFT)
        {
            if (!isHoldLeft) return;
            isHoldLeft = false;
            DEBUG_Left?.SetActive(false);
        }
        else if (direction == Direction.RIGHT)
        {
            if (!isHoldRight) return;
            isHoldRight = false;
            DEBUG_Right?.SetActive(false);
        }
    }

    private void PutUpHand(Direction direction)
    {
        if (direction == Direction.LEFT)
        {
            if (isHoldLeft) return;
            isHoldLeft = true;
            DEBUG_Left?.SetActive(true);
        }
        else if (direction == Direction.RIGHT)
        {
            if (isHoldRight) return;
            isHoldRight = true;
            DEBUG_Right?.SetActive(true);
        }
    }
}
