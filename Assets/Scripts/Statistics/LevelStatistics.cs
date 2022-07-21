using System;

public class LevelStatistics : Singleton<LevelStatistics>
{
    public event EventHandler<int> OnKilledEnemiesAmountChanged;
    public int EnemiesKilled { get; private set; }
    public int MoneyCollected { get; private set; }

    public void IncreaseEnemiesKilled()
    {
        EnemiesKilled++;
        OnKilledEnemiesAmountChanged?.Invoke(this, EnemiesKilled);
    }

    public void IncreaseMoneyCollected(int amount)
    {
        MoneyCollected += amount;
    }
}
