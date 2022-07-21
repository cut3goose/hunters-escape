using System;
using UnityEngine;

public class OnTimerRanOutRoundLimitEventHandler : MonoBehaviour
{
    private void HandleEvent(object s, EventArgs args)
    {
        GameStateData.TrySetNewGameState(GameState.Win);
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        TimerRoundLimitMonoBehaviour.Instance.TimerRoundLimit.OnTimeRanOut -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TimerRoundLimitMonoBehaviour.Instance.TimerRoundLimit.OnTimeRanOut += HandleEvent;
    }

    #endregion
}
