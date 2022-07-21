using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/General/TweenMovementConfig")]
public class TweenMovementConfig : ScriptableObject
{
    public float Duration;
    public Ease Ease;
}