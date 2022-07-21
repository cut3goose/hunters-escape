using UnityEngine;

[CreateAssetMenu(menuName = "Configs/KillsPointer/KillsPointerActivationConfig")]
public class KillsPointerActivationConfig : ScriptableObject
{
    public int KillLessThanToActivate;
    public int TimeLessThanActivate;
}