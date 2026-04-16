using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] private float maxEnergy, regenRate, costPerSecPerHand;
    // Cool down after both hands are down to start energy regen
    [SerializeField] private float regenCoolDown;
    private float currEnergy;
    private bool isRegeneratingEnergy;
    private float regenTimer;

    private void Awake()
    {
        currEnergy = maxEnergy;

        Reset();
    }

    public bool CanBlock()
    {
        return currEnergy > 0f;
    }

    public void Regenerate()
    {
        currEnergy += regenRate * Time.deltaTime;
        ClampCurrEnergy();
    }

    public void UpdateEnergy(bool defendingLeft, bool defendingRight)
    {
        int count = 0;
        count += defendingLeft ? 1 : 0;
        count += defendingRight ? 1 : 0;

        // If currently defending
        if (count > 0)
        {
            currEnergy -= count * costPerSecPerHand * Time.deltaTime;
            ClampCurrEnergy();
            return; 
        }

        // If not defending then check current timer
        if (!isRegeneratingEnergy)
            CheckEnergyRegen();

        // Regenerate if cool down is finished
        if (isRegeneratingEnergy)
        {
            currEnergy += regenRate * Time.deltaTime;
            ClampCurrEnergy(); 
        }
    }

    public void StartDefending()
    {
        ResetRegenTimer(); 
    }

    private void ClampCurrEnergy()
    {
        currEnergy = Mathf.Clamp(currEnergy, 0f, maxEnergy);
    }

    public void Reset()
    {
        ResetRegenTimer();
    }

    private void ResetRegenTimer()
    {
        isRegeneratingEnergy = false;
        regenTimer = regenCoolDown;
    }

    private void CheckEnergyRegen()
    {
        // Return if already regenerating 
        if (isRegeneratingEnergy) return;

        regenTimer -= Time.deltaTime;

        if (regenTimer <= 0f)
        {
            isRegeneratingEnergy = true;
            regenTimer = 0f;
        }
    }

}
