using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "MoneyMovementUIConfig", menuName = "Configs/Money/MoneyMovementUIConfig")]
public class MoneyMovementUIConfig : ScriptableObject
{
    public float MovementDuration;
    public Ease Ease;
}