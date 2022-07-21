using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Movement/SpeedBoostConfig")]
public class SpeedBoostConfig : ScriptableObject
{
    public float SpeedBoostRate;
    public float SpeedBoostEnableTime;
    public float SpeedBoostDisableTime;
    public float DefaultSpeedBoost;
    public Ease Ease;
}