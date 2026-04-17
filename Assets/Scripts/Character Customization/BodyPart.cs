using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public CustomizationSlot slot;
    private MeshFilter meshFilter;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
    }

    public void SetMesh(Mesh target)
    {
        meshFilter.sharedMesh = target;
    }

}