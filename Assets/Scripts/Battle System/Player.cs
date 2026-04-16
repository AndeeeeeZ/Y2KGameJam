using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerRole currentRole;

    private GameInput inputs;

    private void Awake()
    {
        inputs = new GameInput();
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {

        inputs.Disable();
    }

    private void OnPressRight(InputAction.CallbackContext context)
    {
        
    }

    private void OnPressLeft(InputAction.CallbackContext context)
    {

    }

    private void OnPressMiddle(InputAction.CallbackContext context)
    {

    }
}
