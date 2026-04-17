using UnityEngine;

[CreateAssetMenu(menuName = "Customization/Mesh Item List")]
public class MeshItemList : ScriptableObject
{
    public CustomizationSlot slot;
    public Mesh[] items;
    public int index;
    public PartType partType = PartType.MESH;

    public int Count => items == null ? 0 : items.Length;

    public Mesh GetByChangeInIndex(int deltaIndex)
    {
        if (Count == 0)
        {
            return null;
        }

        index = WrapIndex(index + deltaIndex);
        return items[index];
    }

    public Mesh GetByIndex(int i)
    {
        if (Count == 0)
        {
            return null;
        }

        index = WrapIndex(i);
        return items[index];
    }

    public Mesh GetCurrent()
    {
        if (Count == 0)
        {
            return null;
        }

        index = WrapIndex(index);
        return items[index];
    }

    public void Reset()
    {
        index = 0;
    }

    public void SetIndex(int i)
    {
        index = WrapIndex(i);
    }

    private int WrapIndex(int i)
    {
        if (Count == 0)
        {
            return 0;
        }

        return ((i % Count) + Count) % Count;
    }
}