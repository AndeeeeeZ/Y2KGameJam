using UnityEngine;

public class BodyPartsLoader : MonoBehaviour
{
    [SerializeField] private PartsDatabase database;
    [SerializeField] private BodyPart[] bodyParts;
    private int[] meshIndices;

    private void Awake()
    {
        meshIndices = new int[bodyParts.Length];
    }

    private void Start()
    {
        LoadEntireBody();
    }

    public void LoadEntireBody()
    {
        for (int i = 0; i < bodyParts.Length; i++)
            ApplyMesh(database.GetItemList(bodyParts[i].slot), i);
    }

    public void ChangeSelection(CustomizationSlot slot, int deltaIndex)
    {
        int bodyPartIndex = FindBodyPartIndex(slot);
        if (bodyPartIndex == -1) return;

        MeshItemList list = database.GetItemList(slot);
        if (list == null || list.Count == 0)
        {
            Debug.LogWarning("Empty list");
            return;
        }

        int currentItemIndex = meshIndices[bodyPartIndex];
        int nextItemIndex = WrapIndex(currentItemIndex + deltaIndex, list.Count);

        meshIndices[bodyPartIndex] = nextItemIndex;

        ApplyMesh(list, bodyPartIndex);
    }

    public void LoadSlot(CustomizationSlot slot)
    {
        MeshItemList list = database.GetItemList(slot);
        int bodyPartIndex = FindBodyPartIndex(slot);
        ApplyMesh(list, bodyPartIndex);
    }

    private void ApplyMesh(MeshItemList list, int bodyPartIndex)
    {
        Mesh target = list.GetByIndex(meshIndices[bodyPartIndex]);
        bodyParts[bodyPartIndex].SetMesh(target);
    }

    public BodyPart FindBodyPart(CustomizationSlot slot)
    {
        if (bodyParts.Length == 0)
        {
            Debug.LogWarning("Body parts list is empty");
            return null;
        }
        for (int i = 0; i < bodyParts.Length; i++)
        {
            if (bodyParts[i].slot == slot)
            {
                return bodyParts[i];
            }
        }
        Debug.LogWarning($"Unable to find body part with slot {slot}");
        return null;
    }

    // Find the index in bodyParts
    public int FindBodyPartIndex(CustomizationSlot slot)
    {
        if (bodyParts.Length == 0)
        {
            Debug.LogWarning("Body parts list is empty");
            return -1;
        }
        for (int i = 0; i < bodyParts.Length; i++)
        {
            if (bodyParts[i].slot == slot)
            {
                return i;
            }
        }
        Debug.LogWarning($"Unable to find body part with slot {slot}");
        return -1;
    }

    // Find the index of the item within each body part
    public int FindItemIndexInBodyPart(CustomizationSlot slot)
    {
        return meshIndices[FindBodyPartIndex(slot)]; 
    }

    private static int WrapIndex(int index, int count)
    {
        if (count <= 0)
        {
            return 0;
        }
        return ((index % count) + count) % count;
    }
}