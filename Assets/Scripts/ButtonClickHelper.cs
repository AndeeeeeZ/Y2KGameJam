using UnityEngine;
using UnityEngine.UI; 

public class ButtonClickHelper : MonoBehaviour
{
    private Button button; 
    private void Awake()
    {
        button = GetComponent<Button>(); 
    }

    public void PressButton()
    {
        button.onClick?.Invoke(); 
    }
}
