using UnityEngine;

public class LevelRatingDisplayController : MonoBehaviour
{
    [SerializeField] private ElementsDisplayController elementDisplay;
    public void DisplayRating()
    {
        var starsAmount = LevelRatingCalculator.Instance.GetRatingStarsAmount();
        
        elementDisplay.DisplayElements(starsAmount);
    }

    #region State Change Reactions

    private void OnEnable()
    {
        var currentGameState = GameStateData.CurrentGameState;
        if (currentGameState == GameState.Win)
        {
            DisplayRating();
        }
    }

    #endregion
}
