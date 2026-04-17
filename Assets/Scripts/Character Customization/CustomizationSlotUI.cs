using TMPro;
using UnityEngine;

public class MeshCustomizationSlotUI : MonoBehaviour
{
    [SerializeField] private CustomizationSlot slot;
    [SerializeField] private PartsDatabase database;
    [SerializeField] private TMP_Text indexText;

    private BodyPartsLoader currentLoader;

    public void SetTarget(BodyPartsLoader loader)
    {
        currentLoader = loader;
        Refresh();
    }

    public void StepLeft()
    {
        if (currentLoader == null) return;

        currentLoader.ChangeMesh(slot, -1);
    }

    public void StepRight()
    {
        if (currentLoader == null) return;

        currentLoader.ChangeMesh(slot, 1);
    }

    public void Refresh()
    {
        if (database == null || indexText == null)
        {
            return;
        }

        var list = database.GetMeshList(slot);
        if (list == null || list.Count == 0)
        {
            indexText.text = "-";
            return;
        }

        indexText.text = list.index.ToString();
    }
}