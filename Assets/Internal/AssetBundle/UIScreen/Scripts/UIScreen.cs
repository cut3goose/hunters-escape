using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour, IAffectedByGameState
{
    [field: SerializeField] public List<BoolOnStateChangeReaction> BoolOnStateChangeReactions { get; private set; }
    
    private ObjectChainStateChanger _screenObjectChainStateChanger;

    public virtual void ChangeScreenState(GameState newGameStateState)
    {
        var newState = TryGetNewActivityState(newGameStateState);
        TrySetNewActivityState(newState);
    }

    #region Main Actions

    protected virtual bool TryGetNewActivityState(GameState newGameStateState)
    {
        foreach (var selectedReaction in BoolOnStateChangeReactions)
        {
            if (selectedReaction.State != newGameStateState) continue;

            return selectedReaction.AssociatedBoolReaction;
        }
        
        return false;
    }

    protected virtual void TrySetNewActivityState(bool newState)
    {
        _screenObjectChainStateChanger.ChangeGameObjectsStates(newState);
    }

    #endregion

    #region Fields Setting

    public virtual void ChangeState(GameState newState)
    {
        ChangeScreenState(newState);
    }

    #endregion
    
    #region Initialization

    protected virtual void Awake()
    {
        TryGetComponent(out _screenObjectChainStateChanger);
    }

    #endregion
}
