using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private Star starPrefab;
    [SerializeField] private float intervalPerSpawn;

    [Header("Angle")]
    [SerializeField] private float startAngle;
    [SerializeField] private float angleSpeed;

    [Header("Color")]
    [SerializeField] private Color startColor;
    [SerializeField] private float colorSpeed;

    private float timer;
    private float currAngle;
    private float hue;
    private float saturation;
    private float value;
    private float alpha; 

    private void Awake()
    {
        timer = 0f;
        currAngle = startAngle;
        
        Color.RGBToHSV(startColor, out hue, out saturation, out value);
        alpha = startColor.a;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= intervalPerSpawn)
        {
            timer -= intervalPerSpawn;

            currAngle += angleSpeed;

            hue = Mathf.Repeat(hue + colorSpeed, 1f);

            Color currColor = Color.HSVToRGB(hue, saturation, value);
            currColor.a = alpha; 

            Star star = Instantiate(starPrefab, transform);
            star.Initialize(currAngle, currColor);
        }
    }
}