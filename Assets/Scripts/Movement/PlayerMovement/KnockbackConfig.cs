using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Movement/KnockbackConfig")]
public class KnockbackConfig : ScriptableObject
{
    public float Speed;
    public float DirectionMultiplier;
    public float Height;
}