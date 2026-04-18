// CustomizationUIController.cs
using UnityEngine;

public class MaterialSlotUIController : MonoBehaviour
{
    [SerializeField] private MaterialColorSlotUI[] colorSlots;
    [SerializeField] private MaterialTextureSlotUI[] textureSlots;
    [SerializeField] private Material player1;
    [SerializeField] private Material player2;

    private void Awake()
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

    private void SetTarget(Material target)
    {
        for (int i = 0; i < colorSlots.Length; i++)
        {
            colorSlots[i].SetTarget(target);
        }
        for (int i = 0; i < textureSlots.Length; i++)
        {
            textureSlots[i].SetTarget(target);
        }
    }

    public void Randomize()
    {
        foreach (var c in colorSlots)
            c.GetRandom();
        foreach (var t in textureSlots)
            t.GetRandom();
    }

    public void Reset()
    {
        foreach (var c in colorSlots)
            c.Reset();
        foreach (var t in textureSlots)
            t.Reset();
    }
}