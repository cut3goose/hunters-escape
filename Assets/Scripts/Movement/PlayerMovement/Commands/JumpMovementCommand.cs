public class JumpMovementCommand : MovementCommand
{
    private readonly CharacterMovement _characterMovement;

    public JumpMovementCommand(CharacterMovement characterMovement)
    {
        _characterMovement = characterMovement;
    }
    
    public override bool Execute()
    {
        if (ExecuteActiveJump()) return true;
        return TryStartJump();
    }

    protected bool TryStartJump()
    {
        // Try activate new jump
        var isFrontGroundFound = _characterMovement.FrontGroundChecker.CheckForObstacle();
        var isGroundFound = _characterMovement.GroundChecker.CheckForObstacle();
        var isLowWallFound = _characterMovement.LowWallChecker.CheckForObstacle();

        if (!isGroundFound || (isFrontGroundFound && !isLowWallFound)) return false;
        _characterMovement.SetLastMovementType(MovementType.Jump);
        _characterMovement.Jump();

        return true;
    }

    protected bool ExecuteActiveJump()
    {
        var lastActionIsJump = _characterMovement.LastMovementType == MovementType.Jump;
        if (lastActionIsJump)
        {
            _characterMovement.JumpUpdate();
            return true;
        }

        return false;
    }
}
