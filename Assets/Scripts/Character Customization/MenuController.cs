using UnityEngine;

// Controls all the UI and their target
public class MenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] options;
    [SerializeField] private Transform[] targetTransforms;
    [SerializeField] private CustomizationUIController uiController;
    [SerializeField] private MaterialSlotUIController[] materialControllers;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float scaleSpeed = 10f;
    [SerializeField] private float alphaSpeed = 10f;

    [Header("Alpha Per Slot (size 7)")]
    [SerializeField] private float[] slotAlphas;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource leftAudioSource, rightAudioSource;

    private int index;
    private bool[] wasActive;
    private CanvasGroup[] canvasGroups;

    private void Awake()
    {
        index = 0;

        wasActive = new bool[options.Length];
        canvasGroups = new CanvasGroup[options.Length];

        // Ensure each option has a CanvasGroup
        for (int i = 0; i < options.Length; i++)
        {
            CanvasGroup cg = options[i].GetComponent<CanvasGroup>();
            if (cg == null)
                cg = options[i].AddComponent<CanvasGroup>();

            canvasGroups[i] = cg;
        }

        UpdateUI(true);
    }

    private void Update()
    {
        int halfVisible = 2;

        for (int i = 0; i < options.Length; i++)
        {
            int relativeIndex = i - index;

            // Disable buttons unless the current selection
            if (relativeIndex != 0)
            {
                options[i].GetComponent<ButtonController>().SetButtonsActiveness(false);
            }
            else
            {
                options[i].GetComponent<ButtonController>().SetButtonsActiveness(true);
            }

            // Wrap relative index
            if (relativeIndex > options.Length / 2) relativeIndex -= options.Length;
            if (relativeIndex < -options.Length / 2) relativeIndex += options.Length;

            bool shouldBeActive = Mathf.Abs(relativeIndex) <= halfVisible;

            if (shouldBeActive)
            {
                int slotIndex = relativeIndex + 3;

                Transform obj = options[i].transform;

                if (!wasActive[i])
                {
                    if (relativeIndex < 0)
                    {
                        // Spawn from top
                        ApplyInstant(i, 0);
                    }
                    else
                    {
                        // Spawn from bottom
                        ApplyInstant(i, 6);
                    }

                    options[i].SetActive(true);
                }

                // Target slot
                Transform target = targetTransforms[slotIndex];

                // Move
                obj.position = Vector3.Lerp(
                    obj.position,
                    target.position,
                    Time.deltaTime * moveSpeed
                );

                // Scale
                obj.localScale = Vector3.Lerp(
                    obj.localScale,
                    target.localScale,
                    Time.deltaTime * scaleSpeed
                );

                // Alpha
                float targetAlpha = slotAlphas[slotIndex];
                canvasGroups[i].alpha = Mathf.Lerp(
                    canvasGroups[i].alpha,
                    targetAlpha,
                    Time.deltaTime * alphaSpeed
                );
            }
            else
            {
                options[i].SetActive(false);
            }

            wasActive[i] = shouldBeActive;
        }
    }

    // Instantly apply position/scale/alpha from a slot
    private void ApplyInstant(int optionIndex, int slotIndex)
    {
        Transform obj = options[optionIndex].transform;

        obj.position = targetTransforms[slotIndex].position;
        obj.localScale = targetTransforms[slotIndex].localScale;
        canvasGroups[optionIndex].alpha = slotAlphas[slotIndex];
    }

    public void GoUp()
    {
        index--;
        WrapIndex();
    }

    public void GoDown()
    {
        index++;
        WrapIndex();
    }

    public void TriggerCurrentLeft()
    {
        GameObject currentOption = options[index];
        if (currentOption.TryGetComponent(out CustomizationSlotUI UI1))
        {
            UI1.StepLeft();
        }
        else if (currentOption.TryGetComponent(out MaterialTextureSlotUI UI2))
        {
            UI2.StepLeft();
        }
        else if (currentOption.TryGetComponent(out MaterialColorSlotUI UI3))
        {
            UI3.StepLeft();
        }
        else
        {
            // TODO: Play error sound?
            return;
        }

        leftAudioSource.PlayOneShot(audioClip);
    }

    public void TriggerCurrentRight()
    {
        GameObject currentOption = options[index];
        if (currentOption.TryGetComponent(out CustomizationSlotUI UI1))
        {
            UI1.StepRight();
        }
        else if (currentOption.TryGetComponent(out MaterialTextureSlotUI UI2))
        {
            UI2.StepRight();
        }
        else if (currentOption.TryGetComponent(out MaterialColorSlotUI UI3))
        {
            UI3.StepRight();
        }
        else
        {
            // TODO: Play error sound? 
        }
        rightAudioSource.PlayOneShot(audioClip);
    }

    private void WrapIndex()
    {
        index = ((index % options.Length) + options.Length) % options.Length;
    }

    private void UpdateUI(bool instant)
    {
        int halfVisible = 2;

        for (int i = 0; i < options.Length; i++)
        {
            int relativeIndex = i - index;

            if (relativeIndex > options.Length / 2) relativeIndex -= options.Length;
            if (relativeIndex < -options.Length / 2) relativeIndex += options.Length;

            bool shouldBeActive = Mathf.Abs(relativeIndex) <= halfVisible;

            options[i].SetActive(shouldBeActive);
            wasActive[i] = shouldBeActive;

            if (instant && shouldBeActive)
            {
                int slotIndex = relativeIndex + 3;
                ApplyInstant(i, slotIndex);
            }
        }
    }

    public void SwitchAllToPlayer1()
    {
        uiController.ToPlayer1();
        foreach (var m in materialControllers)
        {
            m.ToPlayer1();
            m.Reset();
        }
    }

    public void SwitchAllToPlayer2()
    {
        uiController.ToPlayer2();
        foreach (var m in materialControllers)
        {
            m.ToPlayer2();
            m.Reset();
        }
    }
}