using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Ragdoll/RagdollConfig")]
public class RagdollConfig : ScriptableObject
{
    public int DefaultForce;
    public ForceMode DefaultForceMode;
    public bool FreezeOnStart;
}