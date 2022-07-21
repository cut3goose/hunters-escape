public class ButtonSubscriberSuitableLevel : ButtonSubscriber
{
    protected override void SubscribeOnClickEvent()
    {
        Button.onClick.AddListener(PassedLevelsAmountData.IncreaseLevelsPassedAmount);
        Button.onClick.AddListener(LevelLoader.Instance.LoadSuitableLevel);
    }
}
