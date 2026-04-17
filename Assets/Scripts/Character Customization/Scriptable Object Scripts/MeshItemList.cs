using UnityEngine;

[CreateAssetMenu(menuName = "Customization/Mesh Item List")]
public class MeshItemList : ScriptableObject
{
    public CustomizationSlot slot;
    public Mesh[] items;
    public PartType partType = PartType.MESH;

    public int Count => items == null ? 0 : items.Length;

    public Mesh GetByIndex(int i)
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