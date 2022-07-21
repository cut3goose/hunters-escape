using System;

public class PassedLevelsDisplay : TextDisplayer
{
    private void Start()
    {
        DisplayText((PassedLevelsAmountData.LevelsPassed + 1).ToString());
    }
}
