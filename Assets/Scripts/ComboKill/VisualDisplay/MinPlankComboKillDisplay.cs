using UnityEngine;

public class MinPlankComboKillDisplay : ComboKillDisplay
{
    [SerializeField] protected MinMaxNumber activationRange;

    public override void DisplayCombo(int killsAmount)
    {
        if (killsAmount >= (int)activationRange.Min)
        {
            ActivateEffects(killsAmount);
        }
    }

    protected void ActivateEffects(int killsAmount)
    {
        TextDisplayer.DisplayText(killsAmount.ToString());
        TextTwistEffect.ActivateThenDeactivate();
        TransparencyChangerEffect.ActivateThenDeactivate();
    }
}
