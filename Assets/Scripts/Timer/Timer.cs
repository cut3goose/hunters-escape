using System;
using DG.Tweening;

public class Timer
{
    public event EventHandler<TimerEventArgs> OnTimerTick;
    public event EventHandler OnTimeRanOut;
    
    public int TimeLeft { get; private set; }

    private Tween _timerTween;
    private readonly int _startTime;

    public Timer(int startTime)
    {
        _startTime = startTime;
    }
    
    public void ActivateTimer()
    {
        if (_timerTween != null) return;
        
        TimeLeft = _startTime;

        _timerTween = DOTween.To(() => TimeLeft, x => TimeLeft = x, 0, _startTime)
            .OnUpdate(NotifyTimerTick)
            .SetEase(Ease.Linear)
            .OnComplete(NotifyTimeRanOut);
    }

    public void KillTimerTween()
    {
        _timerTween.Kill();
        _timerTween = null;
    }
    
    public int GetTimePassed()
    {
        var timePassed = _startTime - TimeLeft;
        return timePassed;
    }

    #region Auxiliary Actions

    private void NotifyTimerTick()
    {
        var args = new TimerEventArgs
        {
            LeftTime = TimeLeft,
            StartTime = _startTime
        };
        OnTimerTick?.Invoke(this, args);
    }

    private void NotifyTimeRanOut()
    {
        OnTimeRanOut?.Invoke(this, EventArgs.Empty);
    }

    #endregion
}
