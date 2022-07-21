using UnityEngine;

[CreateAssetMenu(menuName = "Configs/LookAtPosition/LookAtPositionConfig")]
public class LookAtPositionConfig : ScriptableObject
{
    public float RotationSpeed;
    public Vector3 RotationOffset;
}