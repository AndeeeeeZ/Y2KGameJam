// CustomizationUIController.cs
using UnityEngine;

public class CustomizationUIController : MonoBehaviour
{
    [SerializeField] private CustomizationSlotUI[] slots;
    [SerializeField] private MaterialSlotUIController[] materialSlots; 
    [SerializeField] private BodyPartsLoader player1;
    [SerializeField] private BodyPartsLoader player2;
    private BodyPartsLoader current; 

    private void Start()
    {
        SetTarget(player1);
    }

    public void ToPlayer1()
    {
        SetTarget(player1);
    }

    public void ToPlayer2()
    {
        SetTarget(player2);
    }

    private void SetTarget(BodyPartsLoader loader)
    {
        current = loader; 
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetTarget(loader);
        }
    }

    public void RandomizeCurrentModel()
    {
        current.RandomizeAllParts(); 
        foreach (var m in materialSlots)
            m.Randomize(); 
        RefreshAllSlotUI(); 
    }

    public void ResetCurrentModel()
    {
        current.ResetAllParts(); 
        foreach (var m in materialSlots)
            m.Reset(); 
        RefreshAllSlotUI(); 
    }

    private void RefreshAllSlotUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Refresh(); 
        }
    }
}