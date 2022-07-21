using UnityEngine;

public class OnKilledEnemiesAmountChangedEventHandler : MonoBehaviour
{
    [SerializeField] private KilledEnemiesDisplayer killedEnemiesDisplayer;
    
    private void HandleEvent(object s, int amount)
    {
        killedEnemiesDisplayer.DisplayText(amount.ToString());
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        LevelStatistics.Instance.OnKilledEnemiesAmountChanged -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Start()
    {
        LevelStatistics.Instance.OnKilledEnemiesAmountChanged += HandleEvent;
    }

    #endregion
}
