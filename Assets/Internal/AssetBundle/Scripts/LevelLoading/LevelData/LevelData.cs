using UnityEngine;

public class LevelData<T>
{
    [field: SerializeField] public T Level { get; private set; }
    [field: SerializeField] public LevelType LevelType { get; private set; }
}