using System;
using UnityEngine;

public class OnBalanceChangedDataSaveEventHandler : MonoBehaviour
{
    private PlayerBalanceDataSaver _balanceDataSaver;
    
    private void HandleEvent(object s, ChangeAmount balanceChangeAmount)
    {
        _balanceDataSaver.SaveData();
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        PlayerWallet.OnBalanceChanged -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        PlayerWallet.OnBalanceChanged += HandleEvent;
        TryGetComponent(out _balanceDataSaver);
    }

    #endregion
}
