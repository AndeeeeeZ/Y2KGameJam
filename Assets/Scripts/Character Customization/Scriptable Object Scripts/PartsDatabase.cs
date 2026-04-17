using UnityEngine;

[CreateAssetMenu(menuName = "Customization/Database")]
public class PartsDatabase : ScriptableObject
{
    public MeshItemList[] meshItemLists;
    public MaterialItemList[] materialItemLists;

    public MeshItemList GetMeshList(CustomizationSlot slot)
    {
        if (meshItemLists == null) return null;

        for (int i = 0; i < meshItemLists.Length; i++)
        {
            if (meshItemLists[i] != null && meshItemLists[i].slot == slot)
            {
                return meshItemLists[i];
            }
        }

        return null;
    }

    public MaterialItemList GetMaterialList(CustomizationSlot slot)
    {
        if (materialItemLists == null) return null;

        for (int i = 0; i < materialItemLists.Length; i++)
        {
            if (materialItemLists[i] != null && materialItemLists[i].slot == slot)
            {
                return materialItemLists[i];
            }
        }

        return null;
    }
}