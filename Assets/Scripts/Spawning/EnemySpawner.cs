using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event EventHandler<EnemyMovement> OnEnemySpawned;
    public bool IsSpawnAvailable { get; private set; } = true;

    [SerializeField] private EnemySpawnerConfig config;

    public void SpawnEnemy()
    {
        if (!IsSpawnAvailable) return;
        
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        StartCoroutine(ActivateCooldown());
        
        yield return new WaitForSeconds(config.SpawnDelay);
        
        var spawnedEnemy = Instantiate(config.Prefab, transform.position + config.SpawnOffset,
            config.Prefab.transform.rotation);

        TryChangeActivityState(spawnedEnemy);
        NotifyEnemySpawned(spawnedEnemy);
    }

    #region Main Actions

    private void TryChangeActivityState(EnemyMovement spawnedEnemy)
    {
        if (GameStateData.CurrentGameState != GameState.Running) return; 
        
        spawnedEnemy.ChangeActiveState(true);
    }

    private IEnumerator ActivateCooldown()
    {
        IsSpawnAvailable = false; 
        
        yield return new WaitForSeconds(config.Cooldown);

        IsSpawnAvailable = true;
    }

    #endregion

    #region Auxiliary Actions

    private void NotifyEnemySpawned(EnemyMovement enemyMovement)
    {
        OnEnemySpawned?.Invoke(this, enemyMovement);
    }

    #endregion
}