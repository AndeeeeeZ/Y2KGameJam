// CustomizationUIController.cs
using UnityEngine;

public class CustomizationUIController : MonoBehaviour
{
    [SerializeField] private CustomizationSlotUI[] slots;
    [SerializeField] private BodyPartsLoader player1;
    [SerializeField] private BodyPartsLoader player2;

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
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetTarget(loader);
        }
    }
}