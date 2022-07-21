using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnController : Singleton<EnemySpawnController>
{
    [SerializeField] private EnemySpawnControllerConfig config;
    
    private List<EnemySpawner> _spawners;

    public void TrySpawnEnemy()
    {
        if (!PlayerReferencesSingleton.Instance || _spawners.Count == 0) return;
        
        var spawnAmount = config.SpawnedEnemiesCount - SpawnedEnemyStorageMonoBehaviour
            .Instance.SpawnedEnemies.ObjectsInStorage.Count;
        
        if (spawnAmount <= 0) return;

        for (int i = 0; i < spawnAmount; i++)
        {
            var selectedSpawner = GetAvailableSpawner();
            if (!selectedSpawner) return;
            
            selectedSpawner.SpawnEnemy();   
        }
    }

    #region Main Actions

    private EnemySpawner GetAvailableSpawner()
    {
        var closestSpawner = GetClosestSpawner();
        var availableSpawner = _spawners.FirstOrDefault(selectedSpawner => selectedSpawner.IsSpawnAvailable);

        return closestSpawner.IsSpawnAvailable ? closestSpawner : availableSpawner;
    }

    private EnemySpawner GetClosestSpawner()
    {
        EnemySpawner closestSpawner = null;
        var minDistance = 0f;

        foreach (var selectedSpawner in _spawners)
        {
            var distance = Vector3.Distance(PlayerReferencesSingleton.Instance.PlayerTransform.position, 
                selectedSpawner.transform.position);

            if (minDistance == 0 || distance < minDistance)
            {
                closestSpawner = selectedSpawner;
                minDistance = distance;
            }
        }

        return closestSpawner;
    }

    #endregion

    #region Init

    private void Start()
    {
        _spawners = FindObjectsOfType<EnemySpawner>().ToList();
        TrySpawnEnemy();
    }

    #endregion
}