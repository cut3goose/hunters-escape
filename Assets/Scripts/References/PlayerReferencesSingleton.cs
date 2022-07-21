using UnityEngine;

public class PlayerReferencesSingleton : Singleton<PlayerReferencesSingleton>
{
    [field: SerializeField] public Transform PlayerTransform { get; private set; }
}
