using System;
using UnityEngine;

public class OnComboAmountChangedEventHandler : MonoBehaviour
{
    private ComboKillDisplay[] _comboEffects;
    
    private void HandleEvent(object s, int newAmount)
    {
        foreach (var selectedEffect in _comboEffects)
        {
            selectedEffect.DisplayCombo(newAmount);
        }
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        ComboKillCounter.Instance.OnComboAmountChanged -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Start()
    {
        _comboEffects = FindObjectsOfType<ComboKillDisplay>();
        ComboKillCounter.Instance.OnComboAmountChanged += HandleEvent;
    }

    #endregion
}
