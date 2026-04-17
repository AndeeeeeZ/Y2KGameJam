using UnityEngine;

[CreateAssetMenu(menuName = "Customization/Body Part Set")]
public class BodyPartSet : ScriptableObject
{
    [SerializeField] private int[] meshPartIndex; 
    [SerializeField] private int[] materialPartIndex; 
    [SerializeField] private PartsDatabase database; 

    // TODO: Randomize each index

    // TODO: Set the length of the two array to the same as in the data base



}