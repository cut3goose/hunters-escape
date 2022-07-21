using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private PlayerDamageConfig playerDamageConfig;

    public override void TryApplyDamage(int amount, DamageType damageType, bool applyCooldown = false, Vector3 hitDirection = default)
    {
        if (GameStateData.CurrentGameState != GameState.Running) return;
        
        base.TryApplyDamage(amount, damageType, applyCooldown, hitDirection);
    }

    public override void Kill(DamageType damageType, Vector3 hitDirection = default)
    {
        TryApplyDamage(playerDamageConfig.TrapDamage, damageType, true, transform.forward);
    }
}