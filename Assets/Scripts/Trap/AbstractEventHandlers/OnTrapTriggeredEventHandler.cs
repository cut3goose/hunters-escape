using UnityEngine;

public abstract class OnTrapTriggeredEventHandler : MonoBehaviour
{
    protected Trap Trap;

    protected virtual void HandleEvent(object s, Health args)
    {
        DealDamage(args);
    }

    protected abstract void DealDamage(Health health);

    #region State Change Reactions

    protected virtual void OnDestroy()
    {
        Trap.OnTrapTriggered -= HandleEvent;
    }

    #endregion

    #region Initialization

    protected virtual void Awake()
    {
        TryGetComponent(out Trap);
        Trap.OnTrapTriggered += HandleEvent;
    }

    #endregion
}
