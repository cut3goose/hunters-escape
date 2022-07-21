using System;
using System.Collections;
using UnityEngine;

public class ComboKillCounter : Singleton<ComboKillCounter>
{
    public event EventHandler<int> OnComboAmountChanged;
    public int CurrentCombo { get; private set; }

    [SerializeField] private ComboKillCounterConfig config;
    
    public void IncreaseKillsAmount()
    {
        CurrentCombo++;
        NotifyAmountChanged();
        
        StopAllCoroutines();
        StartCoroutine(ResetCombo());
    }

    private IEnumerator ResetCombo()
    {
        yield return new WaitForSeconds(config.ComboResetTime);

        CurrentCombo = 0;
    }

    public void NotifyAmountChanged()
    {
        OnComboAmountChanged?.Invoke(this, CurrentCombo);
    }
}