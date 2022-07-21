using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    private TextDisplayer _textDisplayer;

    public void DisplayTime(int secondsToDisplay)
    {
        var minutes = (secondsToDisplay / 60).ToString();
        var seconds = (secondsToDisplay % 60).ToString();
        if (seconds.Length == 1)
        {
            seconds = "0" + seconds;
        }

        var textToDisplay = $"{minutes}:{seconds}";
        
        _textDisplayer.DisplayText(textToDisplay);
    }
    
    #region Init

    private void Awake()
    {
        TryGetComponent(out _textDisplayer);
    }

    #endregion
}