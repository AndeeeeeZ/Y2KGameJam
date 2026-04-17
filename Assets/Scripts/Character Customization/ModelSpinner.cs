using UnityEngine;

public class ModelSpinner : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float spinSpeed;
    void Update()
    {
        target.transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
    }
}
