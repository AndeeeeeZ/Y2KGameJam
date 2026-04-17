using UnityEngine;

public class CustomizationUIController : MonoBehaviour
{
    [SerializeField] private MeshCustomizationSlotUI[] slots;
    [SerializeField] private BodyPartsLoader player1, player2; 

    private void Start()
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