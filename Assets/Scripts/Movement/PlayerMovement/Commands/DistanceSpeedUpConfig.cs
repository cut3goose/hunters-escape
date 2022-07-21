using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Movement/DistanceSpeedUpConfig")]
public class DistanceSpeedUpConfig : ScriptableObject
{
    public float BoostedSpeed;
    public float DistanceToActivate;
}