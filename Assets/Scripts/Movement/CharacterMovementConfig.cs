using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Configs/Movement/CharacterMovement")]
public class CharacterMovementConfig : ScriptableObject
{
    public float MovementSpeed;
    public float ClimbingSpeed;
    
    public float JumpSpeed;
    public float JumpTime;
    public Ease JumpEase;

    public float FallSpeed;
    public float FallSpeedIncreaseTime;
    public Ease FallEase;
}