using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class MenuInputHandler : MonoBehaviour
{
    private PlayerInput input;

    private InputAction upAction;
    private InputAction downAction;
    private InputAction leftAction;
    private InputAction rightAction;
    private InputAction randomizeAction;
    [SerializeField] private string player2ActionMapName;
    [SerializeField] private UnityEvent onUp;
    [SerializeField] private UnityEvent onDown;
    [SerializeField] private UnityEvent onLeft;
    [SerializeField] private UnityEvent onRight;
    [SerializeField] private UnityEvent onRandomize;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        BindActions();
    }

    private void OnDisable()
    {
        UnbindActions();
    }

    public void BindActions()
    {
        UnbindActions();

        if (input == null || input.currentActionMap == null)
            return;

        upAction = input.currentActionMap.FindAction("Up", true);
        downAction = input.currentActionMap.FindAction("Down", true);
        leftAction = input.currentActionMap.FindAction("Left", true);
        rightAction = input.currentActionMap.FindAction("Right", true);
        randomizeAction = input.currentActionMap.FindAction("Randomize", true);

        upAction.performed += OnUp;
        downAction.performed += OnDown;
        leftAction.performed += OnLeft;
        rightAction.performed += OnRight;
        randomizeAction.performed += OnRandomize;
    }

    public void RebindToPlayer2()
    {
        input.SwitchCurrentActionMap(player2ActionMapName);
        RebindForCurrentMap();
    }

    public void RebindForCurrentMap()
    {
        BindActions();
    }

    private void UnbindActions()
    {
        if (upAction != null) upAction.performed -= OnUp;
        if (downAction != null) downAction.performed -= OnDown;
        if (leftAction != null) leftAction.performed -= OnLeft;
        if (rightAction != null) rightAction.performed -= OnRight;
        if (randomizeAction != null) randomizeAction.performed -= OnRandomize;
    }

    private void OnUp(InputAction.CallbackContext context) => onUp?.Invoke();
    private void OnDown(InputAction.CallbackContext context) => onDown?.Invoke();
    private void OnLeft(InputAction.CallbackContext context) => onLeft?.Invoke();
    private void OnRight(InputAction.CallbackContext context) => onRight?.Invoke();
    private void OnRandomize(InputAction.CallbackContext context) => onRandomize?.Invoke();
}