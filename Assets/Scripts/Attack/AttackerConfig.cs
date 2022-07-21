using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Checking/AttackerConfig", order = 2, fileName = "AttackerConfig")]
public class AttackerConfig : RaycastConfig
{
    public int Damage;
    public float AttackDelay;
}
