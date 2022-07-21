using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Camera/SpeedBoostEffectConfig")]
public class CameraSpeedBoostEffectConfig : ScriptableObject
{
    public float BoostedFOV;
    public float EffectEnableTime;
    public Ease EnableEase;
    
    public float DefaultFOV;
    public float EffectDisableTime;
    public Ease DisableEase;
}