public class RangeComboKillDisplay : MinPlankComboKillDisplay
{
    // experiment
    public override void DisplayCombo(int killsAmount)
    {
        if (killsAmount <= activationRange.Max)
        {
            base.DisplayCombo(killsAmount);
        }
    }
}
