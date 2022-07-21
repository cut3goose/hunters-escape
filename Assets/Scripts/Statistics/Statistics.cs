using UnityEngine;

public class Statistics : MonoBehaviour, IAffectedByGameState
{
    // тут время прохождения всегда будет 0, так как игра кончается при окончании таймера.
    private void OnWin()
    {
        var playTime = GetPlayTime();
    }

    private void OnLose()
    { 
        var playTime = GetPlayTime();
    }

    private int GetPlayTime()
    {
        return TimerRoundLimitMonoBehaviour.Instance.TimerRoundLimit.GetTimePassed();
    }
    
    public void ChangeState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Win:
                OnWin();
                break;
            case GameState.Lose:
                OnLose();
                break;
        }
    }
}
