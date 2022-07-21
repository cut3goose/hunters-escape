public class TrapStatic : OnTrapTriggeredEventHandler
{
    protected override void DealDamage(Health health)
    {
        health.Kill(Trap.TrapConfig.DamageType);
    }
}
