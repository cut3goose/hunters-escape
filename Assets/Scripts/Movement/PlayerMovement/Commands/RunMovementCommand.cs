public class RunMovementCommand : MovementCommand
{
    private readonly CharacterMovement _characterMovement;

    public RunMovementCommand(CharacterMovement characterMovement)
    {
        _characterMovement = characterMovement;
    }
    
    public override bool Execute()
    {
        var lastMovementTypeIsJump = _characterMovement.LastMovementType == MovementType.Jump;
        var lastMovementTypeIsFall = _characterMovement.LastMovementType == MovementType.Fall;
        var lastMovementTypeIsClimb = _characterMovement.LastMovementType == MovementType.Climb;
        var isWallFound = _characterMovement.WallChecker.CheckForObstacle();
        var isGroundFound = _characterMovement.GroundChecker.CheckForObstacle();

        if (lastMovementTypeIsClimb || isWallFound) return false;
        
        if (!lastMovementTypeIsJump && !lastMovementTypeIsFall && isGroundFound)
        {
            _characterMovement.SetLastMovementType(MovementType.Run);
        }
        
        _characterMovement.Run();
        return true;
    }
}
