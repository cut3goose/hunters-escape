using System;

public static class PassedLevelsAmountData
{
    public static event EventHandler<int> OnPassedLevelsAmountUpdated;
    public static int LevelsPassed { get; private set; }

    public static void IncreaseLevelsPassedAmount()
    {
        LevelsPassed++;
        OnPassedLevelsAmountUpdated?.Invoke(null, LevelsPassed);
    }

    public static void SetPassedLevelsAmount(int amount)
    {
        LevelsPassed = amount;
    }
}
