using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button[] Buttons;
    public void SetButtonsActiveness(bool v)
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = v;
        }
    }
}
