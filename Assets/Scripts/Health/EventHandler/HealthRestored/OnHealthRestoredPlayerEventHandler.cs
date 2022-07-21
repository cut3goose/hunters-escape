using System;
using UnityEngine;

public class OnHealthRestoredPlayerEventHandler : MonoBehaviour
{
    [SerializeField] private ElementsDisplayController elementsDisplay;

    private HPRegeneration _hpRegeneration;
    private Health _health;
    
    private void HandleEvent(object s, EventArgs args)
    {
        UpdateHealthDisplay();
        TryRegenerateMoreHp();
    }

    #region Main Actions

    private void TryRegenerateMoreHp()
    {
        if (_health.CurrentHealth != _health.MAXHealth)
        {
            _hpRegeneration.StartRegenerationCoroutine();
        }
    }

    private void UpdateHealthDisplay()
    {
        elementsDisplay.DisplayElements(_health.CurrentHealth);
    }

    #endregion
    
    #region State Change Reactions

    private void OnDestroy()
    {
        _health.OnHealthRestored -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _health);
        _health.OnHealthRestored += HandleEvent;
        
        TryGetComponent(out _hpRegeneration);
    }

    #endregion
}
