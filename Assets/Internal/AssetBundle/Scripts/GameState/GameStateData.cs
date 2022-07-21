using System;

public static class GameStateData
{
    public static event EventHandler<GameStateEventArgs> OnGameStateChanged;
    
    public static GameState CurrentGameState { get; private set; }

    public static void TrySetNewGameState(GameState newGameState)
    {
        CurrentGameState = newGameState;
        NotifyGameStateChanged(newGameState);
    }

    #region Auxiliary Actions

    private static void NotifyGameStateChanged(GameState newGameState)
    {
        var args = new GameStateEventArgs
        {
            GameState = newGameState
        };
        OnGameStateChanged?.Invoke(null, args);
    }

    #endregion
}
