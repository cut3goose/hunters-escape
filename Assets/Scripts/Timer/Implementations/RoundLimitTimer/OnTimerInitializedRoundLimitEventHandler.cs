using UnityEngine;

public class OnTimerInitializedRoundLimitEventHandler : MonoBehaviour
{
    [SerializeField] private TimeDisplay timeDisplay;
    
    private void HandleEvent(object s, int startTime)
    {
        timeDisplay.DisplayTime(startTime);
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        TimerRoundLimitMonoBehaviour.Instance.OnTimerInitialized -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TimerRoundLimitMonoBehaviour.Instance.OnTimerInitialized += HandleEvent;
    }

    #endregion
}
