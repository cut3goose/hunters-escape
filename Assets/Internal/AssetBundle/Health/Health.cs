using System;
using System.Collections;
using UnityEngine;

// Класс описывает здоровье объекта и взаимодействие с ним.
public class Health : MonoBehaviour
{
    public event EventHandler<(Vector3, DamageType)> OnZeroHealth;
    public event EventHandler<(Vector3, DamageType)> OnDamageApplied;
    public event EventHandler OnHealthRestored;

    public bool IsAlive { get; protected set; } = true;
    public int CurrentHealth { get; private set; }
    public int MAXHealth { get; private set; }
    public DamageType LastDamageType { get; private set; }

    [SerializeField] protected HealthConfig Config;

    protected bool IsCooldownActive;

    public virtual void Kill(DamageType damageType, Vector3 hitDirection = default)
    {
        TryApplyDamage(CurrentHealth, damageType, true, hitDirection);
    }
    
    public virtual void TryApplyDamage(int amount, DamageType damageType, bool applyCooldown = false, Vector3 hitDirection = default)
    {
        if (!IsAlive || IsCooldownActive) return;
        
        var changedHp = CurrentHealth - amount;
        CurrentHealth = changedHp < 0 ? 0 : changedHp;
        LastDamageType = damageType;
        
        NotifyDamageApplied(damageType, hitDirection);
        CheckIfDead(damageType, hitDirection);

        if (applyCooldown)
        {
            StartCoroutine(ApplyCooldown());
        }
    }

    public virtual void TryRestoreHealth(int amount)
    {
        if (!IsAlive) return;

        CurrentHealth += amount;
        OnHealthRestored?.Invoke(this, EventArgs.Empty);
    }

    #region Available Actions

    protected virtual void CheckIfDead(DamageType damageType, Vector3 hitDirection)
    {
        if (CurrentHealth > 0) return;
        
        OnZeroHealth?.Invoke(this, (hitDirection, damageType));
    }

    public virtual void RestoreHealth()
    {
        CurrentHealth = MAXHealth;
    }

    protected virtual IEnumerator ApplyCooldown()
    {
        IsCooldownActive = true;
        
        yield return new WaitForSeconds(Config.CooldownTime);

        IsCooldownActive = false;
    }

    protected void NotifyDamageApplied(DamageType damageType, Vector3 hitDirection)
    {
        OnDamageApplied?.Invoke(this, (hitDirection, damageType));
    }

    #endregion

    #region Initialization

    protected virtual void Awake()
    {
        OnZeroHealth += (sender, args) => IsAlive = false;
        
        MAXHealth = Config.MAXHealth;
        RestoreHealth();
    }

    #endregion
}