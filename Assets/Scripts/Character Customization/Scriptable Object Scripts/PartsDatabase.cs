using UnityEngine;

[CreateAssetMenu(menuName = "Customization/Database")]
public class PartsDatabase : ScriptableObject
{
    public MeshItemList[] meshItemLists;

    public int MeshListCount => meshItemLists == null ? 0 : meshItemLists.Length;

    public MeshItemList GetMeshList(CustomizationSlot slot)
    {
        if (meshItemLists == null)
        {
            return null;
        }

        for (int i = 0; i < meshItemLists.Length; i++)
        {
            if (meshItemLists[i] != null && meshItemLists[i].slot == slot)
            {
                return meshItemLists[i];
            }
        }

        return null;
    }

    public Mesh GetMesh(CustomizationSlot slot, int itemIndex)
    {
        MeshItemList list = GetMeshList(slot);
        if (list == null)
        {
            return null;
        }

        return list.GetByIndex(itemIndex);
    }

    public Mesh GetCurrMesh(CustomizationSlot slot)
    {
        MeshItemList list = GetMeshList(slot);
        if (list == null)
        {
            return null;
        }

        return list.GetCurrent();
    }
}