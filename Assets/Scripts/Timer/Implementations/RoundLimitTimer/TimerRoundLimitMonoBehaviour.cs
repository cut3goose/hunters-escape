using System;
using UnityEngine;

public class TimerRoundLimitMonoBehaviour : Singleton<TimerRoundLimitMonoBehaviour>, IAffectedByGameState
{
    public event EventHandler<int> OnTimerInitialized;
    
    [field:SerializeField] public Timer TimerRoundLimit { get; private set; }

    [SerializeField] private TimerConfig timerConfig;

    public void ChangeState(GameState newState)
    {
        if (newState == GameState.Running)
        {
            TimerRoundLimit.ActivateTimer();
        }
        else if (newState == GameState.Lose)
        {
            TimerRoundLimit.KillTimerTween();
        }
    }

    #region Auxiliary Actions
    
    private void NotifyTimerInitialized(int startTime)
    {
        OnTimerInitialized?.Invoke(this, startTime);
    }

    #endregion

    #region Init

    private void Start()
    {
        var startTime = timerConfig.StartTime;
        NotifyTimerInitialized(startTime);
    }

    protected override void Awake()
    {
        base.Awake();

        var startTime = timerConfig.StartTime;
        TimerRoundLimit = new Timer(startTime);
    }

    #endregion
}