using UnityEngine;
using TMPro;
// Taken from a random YouTube
public class TMP_WaveText : MonoBehaviour
{
    public float waveSpeed = 2f;
    public float waveHeight = 10f;
    public float waveSpacing = 0.3f; 

    public float colorSpeed = 2f;
    public bool applyColor = true; 
    public Color startNotHue; 

    private TMP_Text textMesh;
    private TMP_TextInfo textInfo;
    private Vector3[][] originalVertices;
    private float saturation, value; 

    void Awake()
    {
        textMesh = GetComponent<TMP_Text>();
        Color.RGBToHSV(startNotHue, out _, out saturation, out value); 
    }

    void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        textMesh.ForceMeshUpdate();
        textInfo = textMesh.textInfo;

        // Store original vertices
        originalVertices = new Vector3[textInfo.meshInfo.Length][];
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            originalVertices[i] = textInfo.meshInfo[i].vertices.Clone() as Vector3[];
        }
    }

    void Update()
    {
        textMesh.ForceMeshUpdate();
        textInfo = textMesh.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible) continue;

            int meshIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;

            Vector3[] vertices = textInfo.meshInfo[meshIndex].vertices;
            Color32[] colors = textInfo.meshInfo[meshIndex].colors32;

            // Smaller spacing between letters
            float waveOffset = Mathf.Sin(Time.time * waveSpeed + i * waveSpacing) * waveHeight;
            Vector3 offset = new Vector3(0, waveOffset, 0);

            // Animated color using HSV
            float hue = Mathf.Repeat(Time.time * colorSpeed + i * 0.05f, 1f);
            Color color = Color.HSVToRGB(hue, saturation, value);

            for (int j = 0; j < 4; j++)
            {
                // Apply wave
                vertices[vertexIndex + j] =
                    originalVertices[meshIndex][vertexIndex + j] + offset;

                // Apply animated color
                if (applyColor)
                    colors[vertexIndex + j] = color;
            }
        }

        // Apply mesh updates
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textInfo.meshInfo[i].mesh.colors32 = textInfo.meshInfo[i].colors32;
            textMesh.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}