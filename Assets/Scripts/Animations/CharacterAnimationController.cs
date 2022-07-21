using UnityEngine;

public class CharacterAnimationController : AnimatorControllerBase, IAffectedByGameState
{
    [SerializeField] private GameState cheeringGameState;
    [SerializeField] private GameState idleGameState;
    
    public void TryStartRelatedMovementAnimation(MovementType movementType)
    {
        var triggerName = GetTriggerName(movementType);
        if (triggerName == default) return;

        SetOnlyTrigger(triggerName);
    }

    #region Triggers Set

    public void StartCheeringAnimation()
    {
        SetTrigger(Globals.CheeringTrigger, true);
    }

    public void StartIdleAnimation()
    {
        SetTrigger(Globals.IdleTrigger, true);
    }

    #endregion

    #region Values Set

    public void SetMovementSpeed(float value)
    {
        SetFloat(Globals.MovementSpeedAnimatorFloat, value);
    }

    #endregion

    #region Auxiliary Actions

    private string GetTriggerName(MovementType movementType)
    {
        switch (movementType)
        {
            case MovementType.Run:
                return Globals.RunTrigger;
            case MovementType.Jump:
                return Globals.JumpTrigger;
            case MovementType.JumpEnd:
                return Globals.JumpEndTrigger;
            case MovementType.Fall:
                return Globals.FallTrigger;
            case MovementType.FallEnd:
                return Globals.FallEndTrigger;
            case MovementType.Climb:
                return Globals.ClimbTrigger;
            case MovementType.ClimbEnd:
                return Globals.ClimbEndTrigger;
            case MovementType.Idle:
                return Globals.IdleTrigger;
        }

        return default;
    }

    #endregion

    #region State Change Reactions

    public void ChangeState(GameState newState)
    {
        if (newState == cheeringGameState)
        {
            StartCheeringAnimation();
        }
        else if (newState == idleGameState)
        {
            StartIdleAnimation();
        }
    }

    #endregion
}
