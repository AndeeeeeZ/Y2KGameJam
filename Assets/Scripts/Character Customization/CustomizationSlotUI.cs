// CustomizationSlotUI.cs
using TMPro;
using UnityEngine;

public class CustomizationSlotUI : MonoBehaviour
{
    [SerializeField] private CustomizationSlot slot;
    [SerializeField] private PartType partType;
    [SerializeField] private TMP_Text indexText;

    private BodyPartsLoader currentLoader;

    public void SetTarget(BodyPartsLoader loader)
    {
        currentLoader = loader;
        Refresh();
    }

    public void StepLeft()
    {
        if (currentLoader == null)
        {
            Debug.LogWarning("Missing loader"); 
            return;
        }

        currentLoader.ChangeSelection(slot, partType, -1);
        Refresh();
    }

    public void StepRight()
    {
        if (currentLoader == null)
        {
            Debug.LogWarning("Missing loader"); 
            return;
        }

        currentLoader.ChangeSelection(slot, partType, 1);
        Refresh();
    }

    public void Refresh()
    {
        if (indexText == null)
        {
            Debug.LogWarning("Missing index text"); 
            return;
        }

        if (currentLoader == null)
        {
            Debug.LogWarning("Missing loader"); 
            indexText.text = "-";
            return;
        }

        indexText.text = currentLoader.GetIndex(slot, partType).ToString();
    }
}