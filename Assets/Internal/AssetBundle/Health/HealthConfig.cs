using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Health/HealthConfig")]
public class HealthConfig : ScriptableObject
{
    public int MAXHealth;
    public int CooldownTime;
}