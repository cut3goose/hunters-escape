public class OnSpringTrapTriggeredEventHandler : OnTrapTriggeredDelayedReactivationEventHandler
{
    private SpringTrapMovement _springTrapMovement;
    
    protected override void HandleEvent(object s, Health args)
    {
        if (args.GetComponent<PlayerReferencesSingleton>())
        {
            Trap.SetActiveState(true);
            return;
        }
        
        base.HandleEvent(s, args);
        _springTrapMovement.Activate();
        StartCoroutine(_springTrapMovement.ReactivateWithDelay());
    }

    #region Init

    protected override void Awake()
    {
        base.Awake();
        TryGetComponent(out _springTrapMovement);
    }

    #endregion
}
