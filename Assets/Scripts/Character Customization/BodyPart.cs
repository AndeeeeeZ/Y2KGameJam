using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public CustomizationSlot slot;
    private SkinnedMeshRenderer meshFilter;

    private void Awake()
    {
        meshFilter = GetComponent<SkinnedMeshRenderer>();
    }

    public void SetMesh(Mesh target)
    {
        meshFilter.sharedMesh = target;
    }

}