public class SpawnedEnemyStorageMonoBehaviour : Singleton<SpawnedEnemyStorageMonoBehaviour>
{
    public DataStorage<EnemyMovement> SpawnedEnemies = new DataStorage<EnemyMovement>();
}
