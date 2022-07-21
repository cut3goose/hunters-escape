using System;
using UnityEngine;

public class LookAtPositionSmooth : MonoBehaviour, IAffectedByGameState
{
    [SerializeField] protected LookAtPositionConfig config;
    [SerializeField] protected CharacterMovement CharacterMovement;

    protected bool IsActive = true;
    
    protected void LookAtPosition(Vector3 lookPosition)
    {
        if (!CheckIfCanRotate() || !IsActive) return;
        
        var rotationSpeed = config.RotationSpeed * Time.deltaTime;
        
        var deltaPosition = lookPosition - transform.position;
        var desiredRotationEuler = Quaternion.LookRotation(deltaPosition).eulerAngles + config.RotationOffset;
        var desiredRotationQuaternion = Quaternion.Euler(desiredRotationEuler);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotationQuaternion, rotationSpeed);
    }

    #region Auxiliary Actions

    protected bool CheckIfCanRotate()
    {
        var lastActionIsClimbing = CharacterMovement.LastMovementType == MovementType.Climb;
        var desiredDirection = PlayerInput.Direction;
        var currentDirection = transform.forward;

        if (!lastActionIsClimbing) return true;

        return true;
    }

    #endregion

    #region Activity State

    public void SetNewActivityState(bool newState)
    {
        IsActive = newState;
    }

    public void ChangeState(GameState newState)
    {
        if (newState == GameState.Win || newState == GameState.Lose)
        {
            SetNewActivityState(false);
        }
    }

    #endregion
}