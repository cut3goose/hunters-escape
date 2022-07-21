using UnityEngine;

public class OnTimerTickRoundLimitEventHandler : MonoBehaviour
{
    [SerializeField] private TimeDisplay timeDisplay;
    
    private void HandleEvent(object s, TimerEventArgs args)
    {
        timeDisplay.DisplayTime(args.LeftTime);
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        TimerRoundLimitMonoBehaviour.Instance.TimerRoundLimit.OnTimerTick -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TimerRoundLimitMonoBehaviour.Instance.TimerRoundLimit.OnTimerTick += HandleEvent;
    }

    #endregion
}