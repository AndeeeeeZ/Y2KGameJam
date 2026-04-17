using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public PartType partType;
    public CustomizationSlot slot;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        if (partType == PartType.MESH)
        {
            meshFilter = GetComponent<MeshFilter>();
        }
        else if (partType == PartType.MATERIAL)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
    }

    public void SetMesh(Mesh target)
    {
        if (partType != PartType.MESH)
        {
            Debug.LogWarning("This body part only takes mesh");
            return;
        }
        meshFilter.mesh = target;
    }

    public void SetMaterial(Material target)
    {
        if (partType != PartType.MATERIAL)
        {
            Debug.LogWarning("This body part only takes material");
            return;
        }
        meshRenderer.material = target; 
    }
}
