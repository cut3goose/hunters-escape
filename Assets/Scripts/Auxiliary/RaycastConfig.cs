using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Checking/Raycast")]
public class RaycastConfig : ScriptableObject
{
    public float CheckDistance;
    public LayerMask Masks;
}