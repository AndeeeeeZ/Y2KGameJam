using UnityEngine;

[CreateAssetMenu(menuName = "Customization/Material Item List")]
public class MaterialItemList : ScriptableObject
{
    public CustomizationSlot slot;
    public Material[] items;
    public PartType partType = PartType.MATERIAL;

    public int Count => items == null ? 0 : items.Length;

    public Material GetByIndex(int i)
    {
        if (Count == 0) return null;
        return items[WrapIndex(i)];
    }

    public int WrapIndex(int i)
    {
        if (Count == 0) return 0;
        return ((i % Count) + Count) % Count;
    }
}