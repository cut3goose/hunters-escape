using UnityEngine;

public class WreckingBallStaticTrap : TrapStatic
{
    [SerializeField] private FluctationsMovement fluctationsMovement;
    
    protected override void DealDamage(Health health)
    {
        var hitDirection = fluctationsMovement.MovementDirection;
        health.Kill(Trap.TrapConfig.DamageType, hitDirection);
    }
}
