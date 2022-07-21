public class PlayerKnockBackMovementCommand : MovementCommand
{
    private readonly PlayerMovement _playerMovement;

    public PlayerKnockBackMovementCommand(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
    }
    
    public override bool Execute()
    {
        var lastMovementTypeIsKnockBack = _playerMovement.LastMovementType == MovementType.Knockback;
        if (!lastMovementTypeIsKnockBack) return false;

        if (_playerMovement.KnockBackProgress < 1)
        {
            _playerMovement.KnockBackUpdate();
            return true;
        }
        
        _playerMovement.SetLastMovementType(MovementType.KnockbackEnd);
        return false;
    }
}
