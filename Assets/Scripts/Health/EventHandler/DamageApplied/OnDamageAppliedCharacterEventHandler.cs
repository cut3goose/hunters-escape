using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDamageAppliedCharacterEventHandler : MonoBehaviour
{
    protected Health _health;
    
    protected virtual void HandleEvent(object s, (Vector3, DamageType) args)
    {
        
    }

    #region State Change Reactions

    protected virtual void OnDestroy()
    {
        _health.OnDamageApplied -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    protected virtual void Awake()
    {
        TryGetComponent(out _health);
        _health.OnDamageApplied += HandleEvent;
    }

    #endregion
}
