public class ButtonSubscriberRestartLevel : ButtonSubscriber
{
    protected override void SubscribeOnClickEvent()
    {
        Button.onClick.AddListener(LevelLoader.Instance.RestartLevel);
    }
}