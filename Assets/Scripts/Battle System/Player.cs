using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerNum playerNum = PlayerNum.NONE;
    private PlayerRole currentRole;
    private GameInput inputs;

    private void Awake()
    {
        inputs = new GameInput();
        currentRole = PlayerRole.NONE;
    }

    private void OnEnable()
    {
        inputs.Enable();
        if (playerNum == PlayerNum.PLAYER1)
        {
            inputs.Player1.Left.performed += OnPressLeft;
            inputs.Player1.Right.performed += OnPressRight;
            inputs.Player1.Middle.performed += OnPressMiddle;
        }
        else if (playerNum == PlayerNum.PLAYER2)
        {
            inputs.Player2.Left.performed += OnPressLeft;
            inputs.Player2.Right.performed += OnPressRight;
            inputs.Player2.Middle.performed += OnPressMiddle;
        }
        else
        {
            Debug.LogWarning("Player is currently missing player number");
        }
    }

    private void OnDisable()
    {
        if (playerNum == PlayerNum.PLAYER1)
        {
            inputs.Player1.Left.performed -= OnPressLeft;
            inputs.Player1.Right.performed -= OnPressRight;
            inputs.Player1.Middle.performed -= OnPressMiddle;
        }
        else if (playerNum == PlayerNum.PLAYER2)
        {
            inputs.Player2.Left.performed -= OnPressLeft;
            inputs.Player2.Right.performed -= OnPressRight;
            inputs.Player2.Middle.performed -= OnPressMiddle;
        }
        else
        {
            Debug.LogWarning("Player is currently missing player number");
        }
        inputs.Disable();
    }

    private void OnPressRight(InputAction.CallbackContext context)
    {
        if (currentRole == PlayerRole.ATTACKER)
        {

        }
        else if (currentRole == PlayerRole.DEFENDER)
        {

        }
        else
        {
            Debug.LogWarning($"Player: {playerNum} is missing a role");
        }

    }

    private void OnPressLeft(InputAction.CallbackContext context)
    {
        if (currentRole == PlayerRole.ATTACKER)
        {

        }
        else if (currentRole == PlayerRole.DEFENDER)
        {

        }
        else
        {
            Debug.LogWarning($"Player: {playerNum} is missing a role");
        }
    }

    private void OnPressMiddle(InputAction.CallbackContext context)
    {
        if (currentRole == PlayerRole.ATTACKER)
        {

        }
        else if (currentRole == PlayerRole.DEFENDER)
        {

        }
        else
        {
            Debug.LogWarning($"Player: {playerNum} is missing a role");
        }
    }
}
