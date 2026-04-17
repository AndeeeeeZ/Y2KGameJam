using System;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsLoader : MonoBehaviour
{
    [SerializeField] private PartsDatabase database;
    [SerializeField] private BodyPart[] parts;

    private readonly Dictionary<CustomizationSlot, BodyPart> partLookup = new();

    [SerializeField] private int[] meshIndices;
    [SerializeField] private int[] materialIndices;

    private void Awake()
    {
        CacheParts();
        EnsureStateArrays();
    }

    private void Start()
    {
        LoadEntireBody();
    }

    private void CacheParts()
    {
        partLookup.Clear();

        if (parts == null || parts.Length == 0)
        {
            parts = GetComponentsInChildren<BodyPart>(true);
        }

        if (parts == null)
        {
            Debug.LogWarning("No parts exist");
            return;
        }

        for (int i = 0; i < parts.Length; i++)
        {
            BodyPart part = parts[i];
            if (part == null)
            {
                Debug.LogWarning("No parts exist");
                continue;
            }

            partLookup[part.slot] = part;
        }
    }

    private void EnsureStateArrays()
    {
        int slotCount = Enum.GetValues(typeof(CustomizationSlot)).Length;

        if (meshIndices == null || meshIndices.Length != slotCount)
        {
            Array.Resize(ref meshIndices, slotCount);
        }

        if (materialIndices == null || materialIndices.Length != slotCount)
        {
            Array.Resize(ref materialIndices, slotCount);
        }
    }

    public void LoadEntireBody()
    {
        for (int i = 0; i < Enum.GetValues(typeof(CustomizationSlot)).Length; i++)
        {
            LoadSlot((CustomizationSlot)i);
        }
    }

    public void ChangeSelection(CustomizationSlot slot, PartType partType, int deltaIndex)
    {
        if (database == null)
        {
            Debug.LogWarning("Missing database");
            return;
        }

        if (partType == PartType.MESH)
        {
            MeshItemList list = database.GetMeshList(slot);
            if (list == null || list.Count == 0)
            {
                Debug.LogWarning("Empty list");
                return;
            }

            int current = meshIndices[(int)slot];
            int next = WrapIndex(current + deltaIndex, list.Count);
            meshIndices[(int)slot] = next;
            ApplyMesh(slot, list.GetByIndex(next));
        }
        else
        {
            MaterialItemList list = database.GetMaterialList(slot);
            if (list == null || list.Count == 0)
            {
                Debug.LogWarning("Empty list");
                return;
            }

            int current = materialIndices[(int)slot];
            int next = WrapIndex(current + deltaIndex, list.Count);
            materialIndices[(int)slot] = next;
            ApplyMaterial(slot, list.GetByIndex(next));
        }
    }

    public int GetIndex(CustomizationSlot slot, PartType partType)
    {
        return partType == PartType.MESH
            ? meshIndices[(int)slot]
            : materialIndices[(int)slot];
    }

    private void LoadSlot(CustomizationSlot slot)
    {
        if (!partLookup.TryGetValue(slot, out BodyPart bodyPart) || bodyPart == null)
        {
            Debug.LogWarning("Unable to find bodyPart"); 
            return;
        }

        if (bodyPart.partType == PartType.MESH)
        {
            MeshItemList list = database != null ? database.GetMeshList(slot) : null;
            if (list != null && list.Count > 0)
            {
                int index = WrapIndex(meshIndices[(int)slot], list.Count);
                meshIndices[(int)slot] = index;
                bodyPart.SetMesh(list.GetByIndex(index));
            }
        }
        else
        {
            MaterialItemList list = database != null ? database.GetMaterialList(slot) : null;
            if (list != null && list.Count > 0)
            {
                int index = WrapIndex(materialIndices[(int)slot], list.Count);
                materialIndices[(int)slot] = index;
                bodyPart.SetMaterial(list.GetByIndex(index));
            }
        }
    }

    private void ApplyMesh(CustomizationSlot slot, Mesh mesh)
    {
        if (mesh == null)
        {
            return;
        }

        if (!partLookup.TryGetValue(slot, out BodyPart bodyPart) || bodyPart == null)
        {
            return;
        }

        bodyPart.SetMesh(mesh);
    }

    private void ApplyMaterial(CustomizationSlot slot, Material material)
    {
        if (material == null)
        {
            return;
        }

        if (!partLookup.TryGetValue(slot, out BodyPart bodyPart) || bodyPart == null)
        {
            return;
        }

        bodyPart.SetMaterial(material);
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