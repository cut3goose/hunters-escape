public class KillsDisplayController : TextDisplayer
{
    private void OnEnable()
    {
        if (!LevelStatistics.Instance) return;
        
        var killsAmount = LevelStatistics.Instance.EnemiesKilled;
        DisplayText(killsAmount.ToString());
    }
}
