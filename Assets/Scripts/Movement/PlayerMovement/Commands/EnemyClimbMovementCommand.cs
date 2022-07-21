public class EnemyClimbMovementCommand : ClimbMovementCommand
{
    private readonly EnemyMovement _enemyMovement;

    public EnemyClimbMovementCommand(EnemyMovement enemyMovement) : base(enemyMovement)
    {
        _enemyMovement = enemyMovement;
    }

    public override bool Execute()
    {
        if (_enemyMovement.LastMovementType == MovementType.Climb)
        {
            TryEnableClimbSpeedSlowDown();
        }
        
        return base.Execute();
    }

    private void TryEnableClimbSpeedSlowDown()
    {
        var isPlayerInFront = _enemyMovement.FrontPlayerChecker.CheckForObstacle();
        
        if (isPlayerInFront)
        {
            _enemyMovement.SlowDownClimbingSpeed();
            return;
        }

        var currentMovementSpeed = (int) _enemyMovement.CurrentClimbingSpeed;
        var defaultClimbingSpeed = (int) _enemyMovement.MovementConfig.ClimbingSpeed;
        
        var speedIsNotDefault = currentMovementSpeed != defaultClimbingSpeed;
        if (speedIsNotDefault)
        {
            _enemyMovement.SpeedUpClimbingSpeed();
        }
    }
}
