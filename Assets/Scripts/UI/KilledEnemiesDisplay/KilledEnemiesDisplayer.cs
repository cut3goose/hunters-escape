using System;

public class KilledEnemiesDisplayer : TextDisplayer
{
    public override void DisplayText(string killedEnemies)
    {
        //var killGoal = LevelRatingCalculator.Instance.GetMaxRequiredKills();
        var textToDisplay = $"{prefix}{killedEnemies}";
        
        _textLabel.text = textToDisplay;
    }

    #region Init

    private void Start()
    {
        DisplayText("0");
    }

    #endregion
}
