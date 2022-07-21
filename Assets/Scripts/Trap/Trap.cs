using System;
using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public event EventHandler<Health> OnTrapTriggered;
    [field:SerializeField] public TrapConfig TrapConfig { get; private set; }
    public bool IsActive { get; protected set; } = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!IsActive) return;
        
        var health = other.GetComponent<Health>();
        if (!health || !health.IsAlive) return;
        
        NotifyTrapTriggered(health);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!IsActive) return;
        
        var health = other.gameObject.GetComponent<Health>();
        if (!health) return;
        
        NotifyTrapTriggered(health);
    }

    private void NotifyTrapTriggered(Health health)
    {
        OnTrapTriggered?.Invoke(this, health);
    }
    
    
    #region Fields Setting

    public IEnumerator SetActiveStateWithDelay(bool newState)
    {
        yield return new WaitForSeconds(TrapConfig.ReactivationDelay);

        SetActiveState(newState);
    }
    
    public void SetActiveState(bool newState)
    {
        IsActive = newState;
    }

    #endregion
}