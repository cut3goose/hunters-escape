using System;
using UnityEngine;

public class OnEnemyMovementSpawnedEventHandler : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    
    private void HandleEvent(object s, EnemyMovement spawnedEnemyMovement)
    {
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        _enemySpawner.OnEnemySpawned -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _enemySpawner);
        _enemySpawner.OnEnemySpawned += HandleEvent;
    }

    #endregion
}
