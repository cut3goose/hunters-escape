using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Spawning/EnemySpawnerConfig")]
public class EnemySpawnerConfig : ScriptableObject
{
    public Vector3 SpawnOffset;
    public EnemyMovement Prefab;
    public float SpawnDelay;
    public float Cooldown;
}