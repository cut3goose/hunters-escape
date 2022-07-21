public class CollectedMoneyDispalyController : TextDisplayer
{
    private void OnEnable()
    {
        if (!LevelStatistics.Instance) return;
        
        var collectedMoney = LevelStatistics.Instance.MoneyCollected;
        DisplayText(collectedMoney.ToString());
    }
}
