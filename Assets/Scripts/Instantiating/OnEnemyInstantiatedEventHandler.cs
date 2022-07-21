using UnityEngine;

public class OnEnemyInstantiatedEventHandler : MonoBehaviour
{
    private void Start()
    {
        SpawnedEnemyStorageMonoBehaviour.Instance.SpawnedEnemies.AddObjectToStorage(GetComponent<EnemyMovement>());
    }
}
