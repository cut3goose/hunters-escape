public abstract class OnTrapTriggeredDeactivateableEventHandler : OnTrapTriggeredEventHandler
{
    protected override void HandleEvent(object s, Health args)
    {
        base.HandleEvent(s, args);
        DeactivateTrap();
    }

    protected abstract void DeactivateTrap();
}
