using UnityEngine;

public class EnemyRunMovementCommand : RunMovementCommand
{
    private readonly EnemyMovement _enemyMovement;

    public EnemyRunMovementCommand(EnemyMovement enemyMovement) : base(enemyMovement)
    {
        _enemyMovement = enemyMovement;
    }

    public override bool Execute()
    {
        if (!TryEnableDistanceSpeedBoost())
        {
            TryEnableRunSpeedSlowDown();
        }

        return base.Execute();
    }
    
    private void TryEnableRunSpeedSlowDown()
    {
        var isCharacterUnder = _enemyMovement.UnderCharacterChecker.CheckForObstacle();
        
        if (isCharacterUnder)
        {
            _enemyMovement.SlowDownRunSpeed();
            return;
        }

        var currentMovementSpeed = (int) _enemyMovement.CurrentMovementSpeed;
        var defaultMovementSpeed = (int) _enemyMovement.MovementConfig.MovementSpeed;
        
        var speedIsNotDefault = currentMovementSpeed != defaultMovementSpeed;
        if (speedIsNotDefault)
        {
            _enemyMovement.SetDefaultMovementSpeed();
        }
    }
    
    private bool TryEnableDistanceSpeedBoost()
    {
        var playerPosition = PlayerReferencesSingleton.Instance.PlayerTransform.position;
        var distanceToPlayer = Vector3.Distance(_enemyMovement.transform.position, playerPosition);
        
        if (distanceToPlayer > _enemyMovement.DistanceSpeedUpConfig.DistanceToActivate)
        {
            _enemyMovement.EnableSpeedBoost();
            return true;
        }

        var currentMovementSpeed = (int) _enemyMovement.CurrentMovementSpeed;
        var defaultMovementSpeed = (int) _enemyMovement.MovementConfig.MovementSpeed;
        
        var speedIsNotDefault = currentMovementSpeed != defaultMovementSpeed;
        if (speedIsNotDefault)
        {
            _enemyMovement.SetDefaultMovementSpeed();
        }

        return false;
    }
}