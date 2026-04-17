using UnityEngine;

[CreateAssetMenu(menuName = "Customization/Material Item List")]
public class MaterialItemList : ScriptableObject
{
    public CustomizationSlot slot;
    public Material[] items;
    public int index;
    public PartType partType = PartType.MATERIAL; 
    public Material GetByChangeInIndex(int deltaIndex)
    {
        index += deltaIndex;
        index %= items.Length;
        return items[index];
    }

    public Material GetByIndex(int i)
    {
        if (i >= items.Length)
        {
            Debug.LogWarning("Item index out of range"); 
            i %= items.Length; 
        }
        return items[i]; 
    }

    public Material GetCurrent()
    {
        return items[index]; 
    }

    public void Reset()
    {
        index = 0;
    }
}