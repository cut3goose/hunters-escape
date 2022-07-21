using UnityEngine;

public class OnGameStateChangedEventHandler : MonoBehaviour
{
    private IAffectedByGameState[] _affectedByGameStateEnums;
    
    private void HandleEvent(object s, GameStateEventArgs args)
    {
        foreach (var selectedComponent in _affectedByGameStateEnums)
        {
            selectedComponent.ChangeState(args.GameState);
        }
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        GameStateData.OnGameStateChanged -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        _affectedByGameStateEnums = GetComponents<IAffectedByGameState>();
        GameStateData.OnGameStateChanged += HandleEvent;
    }

    #endregion
}
