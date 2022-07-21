using UnityEngine;

public class OnMovementTypeChangedEventHandler : MonoBehaviour
{
    private CharacterAnimationController _animationController;
    
    private CharacterMovement _characterMovement;
    
    private void HandleEvent(object s, MovementType newMovementType)
    {
        _animationController.TryStartRelatedMovementAnimation(newMovementType);
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        _characterMovement.OnMovementTypeChanged -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Start()
    {
        TryGetComponent(out _characterMovement);
        _characterMovement.OnMovementTypeChanged += HandleEvent;

        _animationController = GetComponentInChildren<CharacterAnimationController>();
    }

    #endregion
}
