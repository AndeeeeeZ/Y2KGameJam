using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public PartType partType;
    public CustomizationSlot slot;

    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void SetMesh(Mesh target)
    {
        if (partType != PartType.MESH || meshFilter == null)
        {
            Debug.LogWarning("Wrong type or meshFilter missing"); 
            return;
        }

        meshFilter.sharedMesh = target;
    }

    public void SetMaterial(Material target)
    {
        if (partType != PartType.MATERIAL || meshRenderer == null)
        {
            Debug.LogWarning("Wrong type or meshRenderer missing"); 
            return;
        }

        meshRenderer.sharedMaterial = target;
    }
}