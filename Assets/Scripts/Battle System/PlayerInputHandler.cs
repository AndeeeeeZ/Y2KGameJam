using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Player player;
    private PlayerCombat combat;
    private PlayerDefense defense;

    private PlayerInput input;

    private void Awake()
    {
        player = GetComponent<Player>();
        combat = GetComponent<PlayerCombat>();
        defense = GetComponent<PlayerDefense>();

        input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        input.actions["Left"].performed += OnLeft;
        input.actions["Left"].canceled += OnLeftRelease;

        input.actions["Right"].performed += OnRight;
        input.actions["Right"].canceled += OnRightRelease;

        input.actions["Middle"].performed += OnMiddle;
    }

    private void OnDisable()
    {
        input.actions["Left"].performed -= OnLeft;
        input.actions["Left"].canceled -= OnLeftRelease;

        input.actions["Right"].performed -= OnRight;
        input.actions["Right"].canceled -= OnRightRelease;

        input.actions["Middle"].performed -= OnMiddle;
    }
    private void OnLeft(InputAction.CallbackContext context)
    {
        if (player.currentRole == PlayerRole.ATTACKER)
            combat.RequestAttack(Direction.LEFT);
        else
            defense.RequestBlock(Direction.LEFT, true);
    }

    private void OnLeftRelease(InputAction.CallbackContext context)
    {
        if (player.currentRole == PlayerRole.DEFENDER)
            defense.RequestBlock(Direction.LEFT, false);
    }

    private void OnRight(InputAction.CallbackContext context)
    {
        if (player.currentRole == PlayerRole.ATTACKER)
        {
            combat.RequestAttack(Direction.RIGHT);
        }
        else if (player.currentRole == PlayerRole.DEFENDER)
        {
            defense.RequestBlock(Direction.RIGHT, true);
        }
    }

    private void OnRightRelease(InputAction.CallbackContext context)
    {
        if (player.currentRole == PlayerRole.DEFENDER)
        {
            defense.RequestBlock(Direction.RIGHT, false);
        }
    }

    private void OnMiddle(InputAction.CallbackContext context)
    {
        if (player.currentRole == PlayerRole.ATTACKER)
        {
            combat.RequestFake();
        }
    }
}