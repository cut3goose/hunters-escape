public class FallMovementCommand : MovementCommand
{
    private readonly CharacterMovement _characterMovement;

    public FallMovementCommand(CharacterMovement characterMovement)
    {
        _characterMovement = characterMovement;
    }
    
    public override bool Execute()
    {
        var isGroundFound = _characterMovement.GroundChecker.CheckForObstacle();
        var lastActionIsClimbing = _characterMovement.LastMovementType == MovementType.Climb;
        var lastActionIsJump = _characterMovement.LastMovementType == MovementType.Jump;
        var lastActionIsKnockback = _characterMovement.LastMovementType == MovementType.Knockback;
        var lastActionIsFall = _characterMovement.LastMovementType == MovementType.Fall;

        if (isGroundFound || lastActionIsClimbing || lastActionIsJump || lastActionIsKnockback)
        {
            if (lastActionIsFall)
            {
                _characterMovement.SetLastMovementType(MovementType.FallEnd);
            }

            _characterMovement.ClearFallTween();
            return false;
        }
        
        _characterMovement.TweenCurrentFallSpeed();
        
        _characterMovement.SetLastMovementType(MovementType.Fall);
        _characterMovement.Fall();
        return true;

    }
}
