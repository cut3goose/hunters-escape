using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public abstract class CharacterMovement : MonoBehaviour, IAffectedByGameState
{
    public event EventHandler<MovementType> OnMovementTypeChanged;
    public event EventHandler OnSpeedBoostEnableStarted;
    public event EventHandler OnSpeedBoostDisableStarted;
    public event EventHandler OnSpeedBoostEnded;
    
    public bool IsActive { get; protected set; }
    public MovementType LastMovementType { get; protected set; }
    public float CurrentMovementSpeed { get; protected set; }
    
    [field: SerializeField] public CharacterMovementConfig MovementConfig { get; protected set; }
    [field: SerializeField] public CharacterController CharacterController { get; protected set; }
    
    [field: SerializeField] public RaycastChecker WallChecker { get; protected set; }
    [field: SerializeField] public RaycastChecker GroundChecker { get; protected set; }
    [field: SerializeField] public RaycastChecker FrontGroundChecker { get; protected set; }
    [field: SerializeField] public RaycastChecker LowWallChecker { get; protected set; }

    [SerializeField] protected SpeedBoostConfig SpeedBoostConfig;
    
    // Jump
    protected float CurrentJumpSpeed;
    protected float CurrentFallSpeed;
    protected Tween FallSpeedTween;
    
    // Speed Boost
    public Tween SpeedBoostTween { get; protected set; }
    protected float CurrentSpeedBoost;

    protected virtual void Update()
    {
        new FallMovementCommand(this).Execute();
    }
    
    #region Movement Actions

    public abstract void Run();

    public virtual void Climb()
    {
        var motion = Vector3.up * (MovementConfig.ClimbingSpeed * Time.deltaTime);
        CharacterController.Move(motion);
    }

    public virtual void Fall()
    {
        var motion = Vector3.down * (CurrentFallSpeed * Time.deltaTime);
        CharacterController.Move(motion);
    }

    public virtual void Jump()
    {
        StartCoroutine(JumpCoroutine());
    }

    public virtual void JumpUpdate()
    {
        var motion = Vector3.up * (CurrentJumpSpeed * Time.deltaTime);
        CharacterController.Move(motion);
    }

    protected virtual IEnumerator JumpCoroutine()
    {
        SetLastMovementType(MovementType.Jump);
        
        CurrentJumpSpeed = MovementConfig.JumpSpeed;
        DOTween.To(() => CurrentJumpSpeed, x => CurrentJumpSpeed = x, 0, 
                MovementConfig.JumpTime).SetEase(MovementConfig.JumpEase);
        
        yield return new WaitForSeconds(MovementConfig.JumpTime);
        
        SetLastMovementType(MovementType.JumpEnd);
    }

    #endregion
    
    #region Speed Boost

    public virtual void EnableSpeedBoost()
    {
        SpeedBoostTween?.Kill();
        NotifySpeedBoostActivated();

        var enableProgress = 1 - (CurrentSpeedBoost / SpeedBoostConfig.SpeedBoostRate);
        var enableTime = SpeedBoostConfig.SpeedBoostEnableTime * enableProgress;

        SpeedBoostTween = DOTween.To(() => CurrentSpeedBoost, x => CurrentSpeedBoost = x,
                SpeedBoostConfig.SpeedBoostRate, enableTime)
            .SetEase(SpeedBoostConfig.Ease)
            .OnComplete(NotifySpeedBoostEnded);
    }

    protected virtual void DisableSpeedBoost()
    {
        SpeedBoostTween?.Kill();
        NotifySpeedBoostDeactivated();
        
        SpeedBoostTween = DOTween.To(() => CurrentSpeedBoost, x => CurrentSpeedBoost = x, 
                SpeedBoostConfig.DefaultSpeedBoost, SpeedBoostConfig.SpeedBoostDisableTime)
            .SetEase(SpeedBoostConfig.Ease)
            .OnComplete(NullSpeedBoostTween);
    }

    #endregion

    #region Variables Setting

    public void SetLastMovementType(MovementType movementType)
    {
        if (LastMovementType == movementType) return;
        if (LastMovementType == MovementType.Knockback && movementType == MovementType.Climb) return;
        
        LastMovementType = movementType;
        OnMovementTypeChanged?.Invoke(this, LastMovementType);
    }

    public virtual void SetDefaultMovementSpeed()
    {
        CurrentMovementSpeed = MovementConfig.MovementSpeed;
    }

    #endregion

    #region Event Calls

    protected void NotifySpeedBoostActivated()
    {
        OnSpeedBoostEnableStarted?.Invoke(this, EventArgs.Empty);
    }
    
    protected void NotifySpeedBoostDeactivated()
    {
        OnSpeedBoostDisableStarted?.Invoke(this, EventArgs.Empty);
    } 
    
    protected void NotifySpeedBoostEnded()
    {
        OnSpeedBoostEnded?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    #region Tweens

    public void TweenCurrentFallSpeed()
    {
        if (FallSpeedTween != null) return;
        
        CurrentFallSpeed = 0;
        FallSpeedTween = DOTween.To(() => CurrentFallSpeed, x => CurrentFallSpeed = x,
                MovementConfig.FallSpeed, MovementConfig.FallSpeedIncreaseTime)
            .SetEase(MovementConfig.FallEase);
    }

    public void ClearFallTween()
    {
        FallSpeedTween.Kill();
        FallSpeedTween = null;
    }

    protected void NullSpeedBoostTween()
    {
        SpeedBoostTween = null;
    }

    #endregion

    #region Activation

    public void ChangeState(GameState newState)
    {
        if (newState == GameState.Running)
        {
            ChangeActiveState(true);
        }
        else if(newState == GameState.Win || newState == GameState.Lose)
        {
            ChangeActiveState(false);
        }
    }

    public void ChangeActiveState(bool newState)
    {
        IsActive = newState;
    }

    #endregion

    #region Init

    protected virtual void Awake()
    {
        SetDefaultMovementSpeed();
        CurrentSpeedBoost = SpeedBoostConfig.DefaultSpeedBoost;
        SetLastMovementType(MovementType.Idle);
    }

    #endregion
}