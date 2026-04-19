using TMPro;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [Header("Player References")]
    [SerializeField] private Player player1;
    [SerializeField] private Player player2;
    [SerializeField] private TextMeshProUGUI player1RoleText, player2RoleText;

    [Header("Match Stats")]
    [SerializeField] private float matchTime = 10f;
    [SerializeField] private TextMeshProUGUI timerText;

    private Player currAttacker;
    private Player currDefender;

    private float currentTime;
    private bool isRunning;

    private void Start()
    {
        UpdateTimerUI();

        StartMatch();
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void StartMatch()
    {
        // Initial roles
        currAttacker = player1;
        currDefender = player2;
        ApplyRoles();
        
        currentTime = matchTime;
        isRunning = true;
    }

    private void UpdateTimer()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;

            OnTurnEnds();
        }

        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        int seconds = Mathf.FloorToInt(currentTime);
        int milliseconds = Mathf.FloorToInt((currentTime - seconds) * 100f);

        timerText.text = $"{seconds:00}:{milliseconds:00}";
    }
    public void OnTurnEnds()
    {
        // TODO: swap roles should be called though animation event or smt 
        SwapPlayerRoles();

        // Reset timer for next turn
        currentTime = matchTime;
        isRunning = true;

        player1.Reset();
        player2.Reset();
    }

    private void SwapPlayerRoles()
    {
        Player temp = currAttacker;
        currAttacker = currDefender;
        currDefender = temp;

        ApplyRoles();
    }

    private void ApplyRoles()
    {
        currAttacker.currentRole = PlayerRole.ATTACKER;
        currDefender.currentRole = PlayerRole.DEFENDER;

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (player1RoleText != null)
            player1RoleText.text = player1.currentRole.ToString();

        if (player2RoleText != null)
            player2RoleText.text = player2.currentRole.ToString();
    }


    public bool ResolveAttack(Player attacker, Direction direction)
    {
        if (attacker != currAttacker) return false;
        if (direction == Direction.NONE) return false; 

        Player defender = currDefender;
        PlayerDefense defense = defender.GetComponent<PlayerDefense>();

        bool isBlocked = defense.isHoldLeft && direction == Direction.LEFT
                      || defense.isHoldRight && direction == Direction.RIGHT;

        if (!isBlocked)
        {
            defender.GetComponent<PlayerHealth>().TakeHit();
            Debug.Log("HIT!!!"); 
            return true; 
        }
        else
        {
            Debug.Log("BLOCK!!!");
            return false;  
        }
    }
}