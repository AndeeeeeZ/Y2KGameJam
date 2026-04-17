using UnityEngine.UI; 
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private float increaseSpeed;
    [SerializeField] private float targetSize;

    private float t;

    public void Initialize(float angle, Color color)
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        GetComponent<RawImage>().color = color; 
    }

    private void Update()
    {
        t += Time.deltaTime * increaseSpeed;

        float scale = t * t;
        transform.localScale = Vector3.one * scale;

        if (scale >= targetSize)
        {
            Destroy(gameObject);
        }
    }
}
