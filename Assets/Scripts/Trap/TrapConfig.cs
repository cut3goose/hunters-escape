using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Traps/TrapConfig")]
public class TrapConfig : ScriptableObject
{
    public DamageType DamageType;
    public float ReactivationDelay;
}