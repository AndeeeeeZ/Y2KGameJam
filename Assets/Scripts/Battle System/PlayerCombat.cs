using NUnit.Framework;
using TMPro;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private bool DEBUG = false;
    [SerializeField] private float attackWindow, fakeAttackCoolDown;
    private Player player;
    private MatchManager matchManager;
    private float attackTimer;
    private bool inAction; // Is doing an action or not
    private bool attacking; // Differentiate real and fake attack 
    private Direction attackDirection;

    private void Awake()
    {
        player = GetComponent<Player>();
        Reset();
    }

    private void Start()
    {
        matchManager = player.matchManager;
    }

    // Called in Player
    public void UpdateCombat()
    {
        if (!inAction) return;

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            attackTimer = 0f;
            inAction = false;

            if (attacking)
            {
                // TODO: tell match manager to attack
            }
            attacking = false;
            attackDirection = Direction.NONE; 
        }
    }

    public void RequestAttack(Direction direction)
    {
        if (DEBUG)
            Debug.Log($"Player requested attack in direction {direction}");

        if (!CanAttack())
        {
            if (DEBUG)
                Debug.LogWarning("Cannot attack due to cool down");
            return;
        }

        // TODO: Play attack animation
        attackDirection = direction; 
        attacking = true;
        inAction = true;
        attackTimer = attackWindow;
    }

    public void RequestFake()
    {
        if (DEBUG)
            Debug.Log("Player requested fake attack");

        if (!CanAttack())
        {
            if (DEBUG)
                Debug.LogWarning("Cannot fake attack due to cool down");
            return;
        }

        // TODO: Play fake attack animation
        inAction = true;
        attackTimer = fakeAttackCoolDown;
    }

    private bool CanAttack()
    {
        return !inAction;
    }

    public void Reset()
    {
        attackDirection = Direction.NONE;
        attacking = false;
        inAction = false;
    }

}
