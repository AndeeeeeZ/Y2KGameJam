// BodyPartsLoader.cs
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsLoader : MonoBehaviour
{
    [SerializeField] private PartsDatabase database;
    [SerializeField] private BodyPart[] parts;

    private readonly Dictionary<CustomizationSlot, BodyPart> partLookup = new();

    private void Awake()
    {
        CacheParts();
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
            return;
        }

        for (int i = 0; i < parts.Length; i++)
        {
            BodyPart part = parts[i];
            if (part == null)
            {
                continue;
            }

            partLookup[part.slot] = part;
        }
    }

    public void LoadEntireBody()
    {
        if (database == null || database.meshItemLists == null)
        {
            return;
        }

        for (int i = 0; i < database.meshItemLists.Length; i++)
        {
            MeshItemList list = database.meshItemLists[i];
            if (list == null)
            {
                continue;
            }

            ApplyMesh(list.slot, list.GetCurrent());
        }
    }

    public void ReloadSpecificPart(CustomizationSlot slot)
    {
        if (database == null)
        {
            return;
        }

        MeshItemList list = database.GetMeshList(slot);
        if (list == null)
        {
            return;
        }

        ApplyMesh(slot, list.GetCurrent());
    }

    public void ChangeMesh(CustomizationSlot slot, int deltaIndex)
    {
        if (database == null)
        {
            return;
        }

        MeshItemList list = database.GetMeshList(slot);
        if (list == null)
        {
            return;
        }

        Mesh mesh = list.GetByChangeInIndex(deltaIndex);
        ApplyMesh(slot, mesh);
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
}