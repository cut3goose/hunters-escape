public class ClimbMovementCommand : MovementCommand
{
    private readonly CharacterMovement _characterMovement;

    public ClimbMovementCommand(CharacterMovement characterMovement)
    {
        _characterMovement = characterMovement;
    }
    
    public override bool Execute()
    {
        var isWallFound = _characterMovement.WallChecker.CheckForObstacle();
        var lastActionIsClimbing = _characterMovement.LastMovementType == MovementType.Climb;
        
        if (!isWallFound)
        {
            if (lastActionIsClimbing)
            {
                _characterMovement.SetLastMovementType(MovementType.ClimbEnd);
            }
            
            return false;
        }
        
        _characterMovement.SetLastMovementType(MovementType.Climb);
        _characterMovement.Climb();

        return true;
    }
}
