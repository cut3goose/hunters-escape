public class PlayerRunMovementCommand : RunMovementCommand
{
    private readonly CharacterMovement characterMovement;

    public PlayerRunMovementCommand(CharacterMovement characterMovement) : base(characterMovement)
    {
        this.characterMovement = characterMovement;
    }

    public override bool Execute()
    {
        if (!PlayerInput.HasActiveInput)
        {
            characterMovement.SetLastMovementType(MovementType.Idle);
            return false;
        }

        return base.Execute();
    }
}
