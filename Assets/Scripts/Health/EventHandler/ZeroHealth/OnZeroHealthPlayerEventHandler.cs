using UnityEngine;

public class OnZeroHealthPlayerEventHandler : OnZeroHealthCharacterEventHandler
{
    private PitchDamageEffect _damageEffect;
    
    protected override void HandleEvent(object s, (Vector3, DamageType) args)
    {
        base.HandleEvent(s, args);
        
        GameStateData.TrySetNewGameState(GameState.Lose);
        _damageEffect.ActivateDeathPitchEffect();
    }

    #region Init

    protected override void Awake()
    {
        base.Awake();
        TryGetComponent(out _damageEffect);
    }

    #endregion
}
