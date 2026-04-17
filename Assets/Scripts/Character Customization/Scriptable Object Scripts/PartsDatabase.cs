using UnityEngine;

[CreateAssetMenu(menuName = "Customization/Database")]
public class PartsDatabase : ScriptableObject
{
    public MeshItemList[] meshItemLists; 

    public MeshItemList GetItemList(CustomizationSlot slot)
    {
        if (meshItemLists.Length == 0)
        {
            Debug.LogWarning("Data base's mesh item list is empty"); 
            return null; 
        }

        for (int i = 0; i < meshItemLists.Length; i++)
        {
            if (meshItemLists[i].slot == slot)
            {
                return meshItemLists[i]; 
            }
        }
        Debug.LogWarning($"Unable to find mesh item list with slot {slot}"); 
        return null; 
    }
}