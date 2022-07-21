using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Collectable/Rotation")]
public class CollectableRotationConfig : ScriptableObject
{
    public float RotationSpeed;
    public Vector3 RotationAxis;
}