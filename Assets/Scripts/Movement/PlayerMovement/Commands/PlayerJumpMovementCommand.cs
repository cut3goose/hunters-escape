public class PlayerJumpMovementCommand : JumpMovementCommand
{
    private PlayerMovement _characterMovement;

    public PlayerJumpMovementCommand(PlayerMovement characterMovement) : base(characterMovement)
    {
        _characterMovement = characterMovement;
    }

    public override bool Execute()
    {
        if (ExecuteActiveJump()) return true;
        if (!PlayerInput.HasActiveInput || !_characterMovement.IsActive) return false;

        return TryStartJump();
    }
}
