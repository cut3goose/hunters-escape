using System;
using UnityEngine;

public class OnMoneyDestinationReachedEventHandler : MonoBehaviour
{
    private MoneyMovementUI _moneyMovement;
    
    private void HandleEvent(object s, int newValue)
    {
        PlayerWallet.TryChangeWalletBalance(newValue);
        LevelStatistics.Instance.IncreaseMoneyCollected(newValue);
        _moneyMovement.SetBoolTransactionCompleted(true);
        
        SpawnedMoneyStorage.RemoveSpawnedMoneyFromStorage(gameObject);
        Destroy(gameObject, 0.1f);
    }

    #region State Change Reactions

    private void OnDestroy()
    {
        _moneyMovement.OnMoneyDestinationReached -= HandleEvent;
    }

    #endregion
    
    #region Initialization

    private void Awake()
    {
        TryGetComponent(out _moneyMovement);
        _moneyMovement.OnMoneyDestinationReached += HandleEvent;
    }

    #endregion
}
