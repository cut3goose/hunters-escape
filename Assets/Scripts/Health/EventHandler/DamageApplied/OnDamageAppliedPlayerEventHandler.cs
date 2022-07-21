using System.Collections.Generic;
using UnityEngine;

public class OnDamageAppliedPlayerEventHandler : OnDamageAppliedCharacterEventHandler
{
    [SerializeField] private ElementsDisplayController elementsDisplay;
    
    private HPRegeneration _hpRegeneration;
    private PlayerMovement _playerMovement;
    private IDamageEffect[] _damageEffects;
    
    protected override void HandleEvent(object s, (Vector3, DamageType) args)
    {
        base.HandleEvent(s, args);
        
        StartCoroutine(_playerMovement.StartKnockBack(args.Item1));
        _hpRegeneration.ResetRegenerationCoroutine();
        _hpRegeneration.StartRegenerationCoroutine();
        TriggerDamageEffects();
        UpdateHealthDisplay();
    }

    #region Main Actions

    private void UpdateHealthDisplay()
    {
        elementsDisplay.DisplayElements(_health.CurrentHealth);
    }

    private void TriggerDamageEffects()
    {
        foreach (var selectedEffect in _damageEffects)
        {
            selectedEffect.ActivateEffect();
        }
    }

    #endregion

    #region Init

    private void Start()
    {
        UpdateHealthDisplay();
    }

    protected override void Awake()
    {
        TryGetComponent(out _playerMovement);
        TryGetComponent(out _hpRegeneration);
        _damageEffects = GetComponents<IDamageEffect>();
        
        base.Awake();
    }

    #endregion
}
