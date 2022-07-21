using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Health/HPRegenerationConfig")]
public class HPRegenerationConfig : ScriptableObject
{
    public float RegeneraionTime;
    public int RegenerationAmount;
}