using UnityEngine;

public class OnTrapTriggeredDelayedReactivationEventHandler : OnTrapTriggeredDeactivateableEventHandler
{
    protected override void DealDamage(Health health)
    {
        health.Kill(DamageType.Rigidbody, Vector3.up);
    }

    protected override void DeactivateTrap()
    {
        Trap.SetActiveState(false);
        StartCoroutine(Trap.SetActiveStateWithDelay(true));
    }
}
