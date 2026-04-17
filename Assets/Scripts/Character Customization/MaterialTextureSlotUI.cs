using TMPro;
using UnityEngine;

public class MaterialTextureSlotUI : MonoBehaviour
{
    [SerializeField] private CustomizationSlot slot;
    [SerializeField] private TMP_Text indexText;
    [SerializeField] private Texture2D[] textures;
    [SerializeField] private string targetPropertyName;
    private Material currentMaterial;
    private int index;

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        index = 0;
        Refresh();
    }

    public void SetTarget(Material loader)
    {
        currentMaterial = loader;
        Refresh();
    }

    public void StepLeft()
    {
        index -= 1;
        WrapIndex();
        Refresh();
    }

    public void StepRight()
    {
        index += 1;
        WrapIndex();
        Refresh();
    }

    public void Refresh()
    {
        currentMaterial.SetTexture(targetPropertyName, textures[index]);
        indexText.text = index.ToString();
    }

    private void WrapIndex()
    {
        int count = textures.Length;
        if (count <= 0)
        {
            return;
        }
        index = ((index % count) + count) % count;
    }
}