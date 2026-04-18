using TMPro;
using UnityEngine;

public class CustomizationSlotUI : MonoBehaviour
{
    [SerializeField] private CustomizationSlot slot;
    [SerializeField] private TMP_Text indexText;
    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;

    private BodyPartsLoader currentLoader;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayAudio()
    {
        audioSource.PlayOneShot(clip);
    }

    public void SetTarget(BodyPartsLoader loader)
    {
        currentLoader = loader;
        Refresh();
    }

    public void StepLeft()
    {
        if (currentLoader == null)
        {
            Debug.LogWarning("Missing loader");
            return;
        }

        currentLoader.ChangeSelection(slot, -1);
        PlayAudio();
        Refresh();
    }

    public void StepRight()
    {
        if (currentLoader == null)
        {
            Debug.LogWarning("Missing loader");
            return;
        }

        currentLoader.ChangeSelection(slot, 1);
        PlayAudio();
        Refresh();
    }

    public void Refresh()
    {
        if (indexText == null)
        {
            Debug.LogWarning("Missing index text");
            return;
        }

        if (currentLoader == null)
        {
            Debug.LogWarning("Missing loader");
            indexText.text = "-";
            return;
        }

        indexText.text = currentLoader.FindItemIndexInBodyPart(slot).ToString();
    }
}